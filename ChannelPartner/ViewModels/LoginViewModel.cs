using Acr.UserDialogs;
using ChannelPartner.Models;
using ChannelPartner.Services;
using ChannelPartner.Views;
using Newtonsoft.Json.Linq;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ChannelPartner.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        
       
        private string _textCheckBox;
        private IAllDataServices _IAllDataServices;
        public event PropertyChangedEventHandler PropertyChanged;
        public string termesConditionURL {
            get {
                return "https://www.theshirtshop.in";
            }

        }
       
        public string TextCheckBox
        {
            get => _textCheckBox;
            set
            {
                _textCheckBox = value;
                OnPropertyChanged();
            }
        }
        public Command OnCheckedChanged { get; set; }

        string _username;
        string _passwoord;
        string _errMsg;
        bool _tncAccpt;
        bool _hasErrr;



        public string AppUser_Name
        { get { return _username; } set { _username = value; OnPropertyChanged(); } }
        public string AppUser_Password
        { get { return _passwoord; } set { _passwoord = value; OnPropertyChanged(); } }
        public string ErrorMsg
        { get { return _errMsg; } set { _errMsg = value; OnPropertyChanged();  } }
        public bool TermsCondotionAccpeted
        { get { return _tncAccpt; } set { _tncAccpt = value; OnPropertyChanged(); } }
        public bool HasErrors
        {
            get
            {
                return _hasErrr;
            }
            set
            {
                _hasErrr = value;
                OnPropertyChanged();
            }

        }

        private void updateError()
        {
            if (AppUser_Name==null|| AppUser_Name.Length <= 0)
            {
                ErrorMsg = "Username is Invalid.";
                HasErrors = true;
            }

            else if (AppUser_Password == null || AppUser_Password.Length <= 0)
            {
                ErrorMsg = "Password is Invalid.";
                HasErrors = true;
            }
            else if (!TermsCondotionAccpeted)
            {
                ErrorMsg = "Please accept Terms & Conditions";
                HasErrors = true;
            }
            else
            {
                ErrorMsg = "";
                HasErrors = false;
            }

        }
        public LoginViewModel()
        {
            _IAllDataServices = new AllDataServices();
            OnCheckedChanged = new Command(OnCheckBoxChanged);
        }

        private void OnCheckBoxChanged()
        {
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public ICommand ClickCommand => new Command(() =>
        {
            Device.OpenUri(new System.Uri(termesConditionURL));
        });

       
        public ICommand LoginCommand => new Command(async ()=> 
        {
            updateError();
            if (!HasErrors) {
               var Wait = UserDialogs.Instance.Loading("Wait...", Cancel(), "", true, MaskType.Black);
                Wait.Show();
                try
                {
                    AppLoginClass appLogin = new AppLoginClass() { password = AppUser_Password, userName = AppUser_Name };
                    JObject result = await _IAllDataServices.CheckLoginAsync(appLogin) as JObject;
                    if (result != null)
                    {
                        string type = result["Type"].ToString();
                        if (type == "1")
                        {

                            CPSettings.ChannelPartnerid = result["Result"]["ChannelPartnerid"].ToString();
                            CPSettings.ChannelPartnerName = result["Result"]["ChannelPartnerName"].ToString();
                            CPSettings.MobileNumber = result["Result"]["MobileNumber"].ToString();
                            CPSettings.EmailId = result["Result"]["EmailId"].ToString();
                            Wait.Hide();
                            
                            Task.Run(async () =>
                            {
                                await Task.Delay(100);
                                Device.BeginInvokeOnMainThread(() =>
                                {
                                    Application.Current.MainPage = new MainPage();
                                });
                            });
                        }
                        else
                        {
                            await App.Current.MainPage.DisplayAlert("Error!", "Invalid Username or Password.", "Ok");
                        }

                        Wait.Hide();

                    }
                    else {
                        Wait.Hide();
                    }
                }
                catch (Exception e) {
                    Wait.Hide();
                }

            }

        });
        private Action Cancel()
        {
            var ca = new CancellationTokenSource();
            return ca.Cancel;
        }
    }
}