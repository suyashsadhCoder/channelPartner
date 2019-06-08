using System;
using System.Collections.Generic;
using ChannelPartner.ViewModels;
using Xamarin.Forms;

namespace ChannelPartner.Views
{
    public partial class LoginPage : ContentPage
    {
        LoginViewModel loginviewmodel;


        public LoginPage()
        {
            InitializeComponent();
            this.BindingContext = loginviewmodel = new LoginViewModel();
           
        }

        private void BtnForgetPassword_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new ForgetPasswordView());
        }
    }
}
