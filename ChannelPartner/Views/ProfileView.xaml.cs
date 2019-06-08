using ChannelPartner.ViewModels;
using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace ChannelPartner.Views
{
    public partial class ProfileView : ContentPage
    {
       public ProfileViewModel viewModel;
        public ProfileView()
        {
            InitializeComponent();
            this.BindingContext = viewModel = new ProfileViewModel();
        }
    }
}
