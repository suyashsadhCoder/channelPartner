using ChannelPartner.ViewModels;
using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace ChannelPartner.Views
{
    public partial class FranchiseeDetailsView : ContentPage
    {
       public FranchiseeDetailsViewModel viewModel;
        private string fraid;

        public FranchiseeDetailsView()
        {
            InitializeComponent();
            this.BindingContext = viewModel = new FranchiseeDetailsViewModel("");
        }
        public FranchiseeDetailsView(string frid)
        {
            InitializeComponent();
            fraid = frid;
            this.BindingContext = viewModel = new FranchiseeDetailsViewModel(frid);
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.getDetailsFromServer();
        }

       
        void Handle_ValueChanged(object sender, SegmentedControl.FormsPlugin.Abstractions.ValueChangedEventArgs e)
        {
            switch (e.NewValue)
            {
                case 0:
                   viewModel.isLeadgerView = true;
                    viewModel.isListView = false;
                    break;
                case 1:
                    viewModel.isLeadgerView = false;
                    viewModel.isListView = true;
                    break;
               
            }
        }
    }
}
