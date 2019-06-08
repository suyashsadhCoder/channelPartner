using ChannelPartner.Models;
using ChannelPartner.ViewModels;
using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace ChannelPartner.Views
{
    public partial class FranhiseeRegistarion : ContentPage
    {
        FranchiseRegistrationViewModel viewModel;
        public FranhiseeRegistarion()
        {
            InitializeComponent();
            this.BindingContext = viewModel= new FranchiseRegistrationViewModel(Navigation);
            string a = viewModel._Franchise_Name;
            

        }
        private void Button_Clicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var Secondary_Mobile_No = button?.BindingContext as MultipleContect_Class;
            var vm = BindingContext as FranchiseRegistrationViewModel;
            vm?.DeleteRowCommand.Execute(Secondary_Mobile_No);
        }

        private void RemoveSecondaryImage(object sender, EventArgs e)
        {


            viewModel?.DeleteRetailerSeconaryImageCommand.Execute((sender as Button).CommandParameter);
        }

        private void FranchiseName_Completed(object sender, EventArgs e)
        {
            FranchiseGSTNo.Focus();
        }

        private void FranchiseGSTNo_Completed(object sender, EventArgs e)
        {
            FranchiseOwnerName.Focus();
        }

        private void FranchiseOwnerName_Completed(object sender, EventArgs e)
        {
            FranchiseEmailId.Focus();
        }

        private void FranchiseEmailId_Completed(object sender, EventArgs e)
        {
            FranchiseMobileNo.Focus();
        }

        private void FranchiseMobileNo_Completed(object sender, EventArgs e)
        {
            StateMasterList.Focus();
        }

        private void CityList_SelectedIndexChanged(object sender, EventArgs e)
        {
            FranchiseAddress.Focus();
        }

        private void FranchiseAddress_Completed(object sender, EventArgs e)
        {
            FranchiseParmanentAddress.Focus();
        }

        private void FranchisePanNo_Completed(object sender, EventArgs e)
        {
            FranchiseAdharNo.Focus();
        }

        private void FranchiseAdharNo_Completed(object sender, EventArgs e)
        {
            FranchiseBankName.Focus();
        }

        private void FranchiseBankName_Completed(object sender, EventArgs e)
        {
            FranchiseAccountNo.Focus();
        }

        private void FranchiseAccountNo_Completed(object sender, EventArgs e)
        {
            FranchiseIFCCode.Focus();
        }

        private void FranchiseParmanentAddress_Completed(object sender, EventArgs e)
        {
            FranchisePanNo.Focus();
        }
        private void Franchise_Pincode_Completed(object sender, EventArgs e)
        {
            FranchiseParmanentAddress.Focus();

        }
    }
}
