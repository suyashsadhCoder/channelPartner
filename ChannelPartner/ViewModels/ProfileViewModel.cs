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
    public class ProfileViewModel:BaseViewModel
    {
        UpdateProfileModel _model;
        bool _isEditMode;
        public bool IsEditMode { get { return _isEditMode; } set { _isEditMode = value; OnPropertyChanged(); } }

        string _buttonTitle;
        public string ButtonTitle { get { return _buttonTitle; } set { _buttonTitle = value; OnPropertyChanged(); }  }

        public UpdateProfileModel ProfileModel { get { return _model; } set { _model = value; OnPropertyChanged(); } }
        public ProfileViewModel()
        {
            IsEditMode = false;
            ButtonTitle = "Edit";
            _IAllDataServices = new AllDataServices();
            ProfileModel = new UpdateProfileModel() { ChannelPartnerid = CPSettings.ChannelPartnerid,
                ChannelPartnerName = CPSettings.ChannelPartnerName, email = CPSettings.EmailId,
                MobileNumber =CPSettings.MobileNumber };

        }
        string _ErrorMsg;
        public string ErrorMsg { get { return _ErrorMsg; } set { _ErrorMsg = value; OnPropertyChanged(); } }
        private IAllDataServices _IAllDataServices;
        public ICommand Updatechange => new Command(() =>
        {
            if (IsEditMode)
            {
                if (validateFieldes())
                {
                    callUpdateProfile();
                }

            }
            else {
                ButtonTitle = "Submit";
                IsEditMode = true;

            }
            

        });
        private Action Cancel()
        {
            var ca = new CancellationTokenSource();
            return ca.Cancel;
        }
        private async void callUpdateProfile()
        {
            var Wait = UserDialogs.Instance.Loading("Wait...", Cancel(), "", true, MaskType.Black);
            Wait.Show();
            try
            {
                
                JObject result = await _IAllDataServices.UpdateChannelPartnerProfile(ProfileModel) as JObject;
                if (result != null)
                {
                    string type = result["Type"].ToString();
                    if (type == "1")
                    {
                        IsEditMode = false;
                        ButtonTitle = "Edit";
                        CPSettings.ChannelPartnerid = ProfileModel.ChannelPartnerid;
                        CPSettings.ChannelPartnerName = ProfileModel.ChannelPartnerName;
                        CPSettings.MobileNumber = ProfileModel.MobileNumber;
                       CPSettings.EmailId = ProfileModel.email;
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
            if (ProfileModel.MobileNumber.Length != 10)
            {
                ErrorMsg = "Please enter valid Mobile Number.";
                return false;
            }
            else if (ProfileModel.ChannelPartnerName.Length == 0)
            {
                ErrorMsg = "Please enter Name.";
                return false;
            }
            else
            {
                ErrorMsg = "";
                return true;
            }



        }

    }
}
