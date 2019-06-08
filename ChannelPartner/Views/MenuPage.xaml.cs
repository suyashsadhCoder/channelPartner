using ChannelPartner.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ChannelPartner.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPage : ContentPage
    {
        MainPage RootPage { get => Application.Current.MainPage as MainPage; }
        List<HomeMenuItem> menuItems;
        public MenuPage()
        {
            InitializeComponent();
            nameTitle.Text = "Hi, " +CPSettings.ChannelPartnerName;
            menuItems = new List<HomeMenuItem>
            {
                new HomeMenuItem {Id = MenuItemType.Home, Title="Home",ImageName="profile" },
                new HomeMenuItem {Id = MenuItemType.Franchise, Title="Franchise",ImageName="profile" },
                new HomeMenuItem {Id = MenuItemType.NewFranchise, Title="New Franchise",ImageName="alloted_franch" },
                new HomeMenuItem {Id = MenuItemType.payments, Title="Payments" ,ImageName="alloted_franch"},
                new HomeMenuItem {Id = MenuItemType.Profile, Title="Profile",ImageName="contact" },
                new HomeMenuItem {Id = MenuItemType.changePassword, Title="Change Password",ImageName="changepwd" },
                
            };

            ListViewMenu.ItemsSource = menuItems;

            ListViewMenu.SelectedItem = menuItems[0];
            ListViewMenu.ItemSelected += async (sender, e) =>
            {
                if (e.SelectedItem == null)
                    return;


                await RootPage.NavigateFromMenu((HomeMenuItem)e.SelectedItem);
            };
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var res = await DisplayAlert("Logout!!", "Are you sure want to Logout?", "Ok", "Cancel");
            if (res) {
                CPSettings.ChannelPartnerid ="";
                CPSettings.ChannelPartnerName = "";
                CPSettings.MobileNumber = "";
                CPSettings.EmailId = "";
                App.Current.MainPage = new NavigationPage(new LoginPage()
                {
                    Title = "Login"
                });
            }
        }
       
    }
}