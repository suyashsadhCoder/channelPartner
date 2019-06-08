using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ChannelPartner.Views;
using ChannelPartner.Models;
using ChannelPartner.Controls;
using System.Threading.Tasks;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace ChannelPartner
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();
            Task.Run(async () =>
            {
                await Task.Delay(100);
                Device.BeginInvokeOnMainThread(async () =>
                {
                    Permissions ps = new Permissions();
                    await ps.CheckGpsAsync();
                });
            });

            try
            {
                if (CPSettings.ChannelPartnerid != null && CPSettings.ChannelPartnerid.Length > 0)
                {
                    MainPage = new MainPage();
                }
                else
                {
                    MainPage = new NavigationPage(new LoginPage()
                    {
                        Title = "Login"
                    });

                }


            }
            catch (Exception e) {
                MainPage = new NavigationPage(new LoginPage()
                {
                    Title = "Login"
                });
            }
            
           
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
