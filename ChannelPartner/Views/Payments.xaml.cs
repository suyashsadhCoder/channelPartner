using ChannelPartner.ViewModels;
using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace ChannelPartner.Views
{
    public partial class Payments : ContentPage
    {
        public PaymentViewModelcs viewModel;
        public Payments()
        {
            InitializeComponent();
            this.BindingContext = viewModel = new PaymentViewModelcs();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.initialiseList();
        }
    }
}
