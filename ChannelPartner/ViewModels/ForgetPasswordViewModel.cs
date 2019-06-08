using Acr.UserDialogs;
using ChannelPartner.Services;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ChannelPartner.ViewModels
{
    public class ForgetPasswordViewModel: BaseViewModel
    {
        private string _primeryNumber;
        

        private IAllDataServices _IAllDataServices;
        public INavigation Navigation { get; set; }
        public string strPrimeryNumber
        {
            get
            {
                return _primeryNumber;
            }
            set
            {
                _primeryNumber = value;
                OnPropertyChanged();
            }

        }
        public ICommand forgetCommand { get; set; }
        public ForgetPasswordViewModel(INavigation navigation)
        {
            this.forgetCommand = new Command(async () => await forgetPasswordCommand());
            Navigation = navigation;
        }

        private async Task forgetPasswordCommand()
        {
            if (!string.IsNullOrEmpty(strPrimeryNumber) && strPrimeryNumber.Length == 10 && !strPrimeryNumber.Contains(" "))
            {
                var Wait = UserDialogs.Instance.Loading("Wait...", null, null, true, MaskType.Black);
                Wait.Show();
                _IAllDataServices = new AllDataServices();
                JObject result = await _IAllDataServices.getForgetPassword(strPrimeryNumber);
                Wait.Hide();
                if (result["Type"].ToString() == "1")
                {
                    await App.Current.MainPage.DisplayAlert(result["ResponseMessage"].ToString(), result["Result"].ToString(), "Ok");
                    Task.Run(async () =>
                            {
                                await Task.Delay(100);
                                Device.BeginInvokeOnMainThread(async () =>
                                {
                                    await Navigation.PopModalAsync();
                                });
                            });
                    
                }
                else
                {

                    await App.Current.MainPage.DisplayAlert(result["ResponseMessage"].ToString(), result["Result"].ToString(), "Ok");
                    
                }

            }
            else
            {

                await App.Current.MainPage.DisplayAlert("Error", "Invalid Mobile Number!!", "Ok");

            }
        }
    }
}
