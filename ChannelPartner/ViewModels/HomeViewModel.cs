using Acr.UserDialogs;
using ChannelPartner.Models;
using ChannelPartner.Services;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading;
using Xamarin.Forms;

namespace ChannelPartner.ViewModels
{
    public class HomeViewModel:BaseViewModel
    {
        string _strGreet;
        public string strGreeting { get { return _strGreet; } set { _strGreet = value; OnPropertyChanged(); } }
        DashboardModel _dashboardModel;
        private IAllDataServices _IAllDataServices;
        public DashboardModel DashboardModelItem { get { return _dashboardModel; } set { _dashboardModel = value; OnPropertyChanged(); } }
        public HomeViewModel() {
            _IAllDataServices = new AllDataServices();
            strGreeting = "Welcome, " + CPSettings.ChannelPartnerName;
            updateDashboard();

        }

        private async void updateDashboard()
        {
            var Wait = UserDialogs.Instance.Loading("Wait...", Cancel(), "", true, MaskType.Black);
            Wait.Show();
            try
            {

                JObject result = await _IAllDataServices.getChannelPartnerDashboard(CPSettings.ChannelPartnerid) as JObject;
                if (result != null)
                {
                    var type = (int)result["Type"];
                    if (type == 1)
                    {
                        DashboardModelItem = JsonConvert.DeserializeObject<DashboardModel>(result["Result"].ToString());
                        if (DashboardModelItem==null)
                        {
                            await App.Current.MainPage.DisplayAlert("Oops!", "No Franchisee found.", "Ok");


                        }

                    }
                    else
                    {
                        await App.Current.MainPage.DisplayAlert("Error!", (string)result["ResponseMessage"], "Ok");
                    }
                    Wait.Hide();


                }
                else
                {
                    Wait.Hide();
                }
            }
            catch (Exception e)
            {
                Wait.Hide();
            }
        }
        private Action Cancel()
        {
            var ca = new CancellationTokenSource();
            return ca.Cancel;
        }
    }
}
