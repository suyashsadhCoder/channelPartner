using ChannelPartner.ViewModels;
using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace ChannelPartner.Views
{
    public partial class ChangePassword : ContentPage
    {
        ChangePasswordViewModel ViewModel;
        public ChangePassword()
        {
            InitializeComponent();
            this.BindingContext = ViewModel = new ChangePasswordViewModel();

        }
    }
}
