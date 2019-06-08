using ChannelPartner.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ChannelPartner.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : MasterDetailPage
    {
        Dictionary<int, NavigationPage> MenuPages = new Dictionary<int, NavigationPage>();
        public MainPage()
        {
            InitializeComponent();

            MasterBehavior = MasterBehavior.SplitOnPortrait;
            
            MenuPages.Add((int)MenuItemType.Home, (NavigationPage)Detail);
        }

        public async Task NavigateFromMenu(HomeMenuItem item)
        {
            int id = (int)item.Id;
            if (!MenuPages.ContainsKey(id))
            {
                switch (id)
                {
                    case (int)MenuItemType.Home:
                        MenuPages.Add(id, new NavigationPage(new HomeView() { 
                        Title = item.Title
                        }));
                        break;
                    case (int)MenuItemType.Franchise:
                        MenuPages.Add(id, new NavigationPage(new AllotedFranchis()
                        {
                            Title = item.Title
                        }));
                        break;
                    case (int)MenuItemType.NewFranchise:
                        MenuPages.Add(id, new NavigationPage(new FranhiseeRegistarion()
                        {
                            Title = item.Title
                        }));
                        break;
                   
                    case (int)MenuItemType.payments:
                        MenuPages.Add(id, new NavigationPage(new Payments()
                        {
                            Title = item.Title
                        }));
                        break;
                    case (int)MenuItemType.Profile:
                        MenuPages.Add(id, new NavigationPage(new ProfileView()
                        {
                            Title = item.Title
                        }));
                        break;
                    case (int)MenuItemType.changePassword:
                        MenuPages.Add(id, new NavigationPage(new ChangePassword()
                        {
                            Title = item.Title
                        }));
                        break;
                }
            }

            var newPage = MenuPages[id];

            if (newPage != null && Detail != newPage)
            {
                Detail = newPage;

                if (Device.RuntimePlatform == Device.Android)
                    await Task.Delay(100);

                IsPresented = false;
            }
        }
    }
}