using Acr.UserDialogs;
using ChannelPartner.Models;
using ChannelPartner.Services;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Windows.Input;
using Xamarin.Forms;

namespace ChannelPartner.ViewModels
{
    public class ChangePasswordViewModel:BaseViewModel
    {

        string _oldPassword;
        public string oldPassword { get { return _oldPassword; } set { _oldPassword = value; OnPropertyChanged(); } }
        string _newPassword;
        public string newPassword { get { return _newPassword; } set { _newPassword = value; OnPropertyChanged(); } }
        string _conPassword;
        public string conPassword { get { return _conPassword; } set { _conPassword = value; OnPropertyChanged(); } }

        string _ErrorMsg;
        public string ErrorMsg { get { return _ErrorMsg; } set { _ErrorMsg = value; OnPropertyChanged(); } }
        private IAllDataServices _IAllDataServices;
        public ICommand Passwordchange => new Command(() =>
        {
            if (validateFieldes()) {
                callChangePassword();
            }
            
        });
        private Action Cancel()
        {
            var ca = new CancellationTokenSource();
            return ca.Cancel;
        }
        private async void callChangePassword()
        {
            var Wait = UserDialogs.Instance.Loading("Wait...", Cancel(), "", true, MaskType.Black);
            Wait.Show();
            try
            {
                ChangePasswordModel model = new ChangePasswordModel()
                {
                    ChannelPartnerid = CPSettings.ChannelPartnerid,
                    newPassword = newPassword, oldPassword = oldPassword
                };
                JObject result = await _IAllDataServices.UpdateChannelPartnerPassword(model) as JObject;
                if (result != null)
                {
                    string type = result["Type"].ToString();
                    if (type == "1")
                    {
                        oldPassword = "";
                        newPassword = "";
                        conPassword = "";
                        await App.Current.MainPage.DisplayAlert(result["ResponseMessage"].ToString(), result["Result"].ToString(), "Ok");
                    }
                    else
                    {
                        await App.Current.MainPage.DisplayAlert("Error!", "Passwords Could not be changed.", "Ok");
                    }
                    Wait.Hide();


                }
                else
                {
                    Wait.Hide();
                }
            }
            catch (Exception e)
            {
                Wait.Hide();
            }
        }

        private bool validateFieldes()
        {
            if (oldPassword.Length == 0)
            {
                ErrorMsg = "Please enter Old Password.";
                return false;
            }
            else if (newPassword.Length == 0)
            {
                ErrorMsg = "Please enter New Password.";
                return false;
            }
            else if (conPassword.Length == 0)
            {
                ErrorMsg = "Please Confirm Password.";
                return false;
            }
            else if (conPassword != newPassword)
            {
                ErrorMsg = "Both Password Do not match.";
                return false;
            }
            else
            {
                ErrorMsg = "";
                return true;
            }



        }

        public ChangePasswordViewModel() {
            oldPassword = "";
            newPassword = "";
            conPassword = "";
            _IAllDataServices = new AllDataServices();

        }
    }
}
