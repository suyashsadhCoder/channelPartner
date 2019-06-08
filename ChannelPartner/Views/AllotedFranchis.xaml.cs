using System;
using System.Collections.Generic;
using ChannelPartner.Models;
using ChannelPartner.ViewModels;
using Xamarin.Forms;

namespace ChannelPartner.Views
{
    public partial class AllotedFranchis : ContentPage
    {
        public AllotedFranciseViewModel viewModel;
        public AllotedFranchis()
        {
            InitializeComponent();
            this.BindingContext = viewModel = new AllotedFranciseViewModel();
            FranchiseListView.ItemTapped += FranchiseListView_ItemTapped; ;
        }

        private void FranchiseListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var item = e.Item as FranchiseeDetailModel;
            Navigation.PushAsync(new FranchiseeDetailsView(item.franchiseId));
        }

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
           
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.initialiseList();
        }

        private async void ImageEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
            var str = e.NewTextValue;
                if (str.Length > 2)
                {
                    var filter = new FranciseSearchFilter()
                    {
                       
                        CurrentPage = "1",
                        SearchBy = str,
                        SortDirection = "ASC",
                        PageSize = "50",
                        SortExpression = "FranchiseSellId",
                       ChannelPartnerId = CPSettings.ChannelPartnerid
            };
                FranchiseListView.ItemsSource =await viewModel.LoadListWithFilter(filter);
                }
                else
                {
                FranchiseListView.ItemsSource = viewModel.itemsList;
                }
           
        }
    }
}
