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
    public class PaymentViewModelcs: BaseViewModel
    {
        public ObservableCollection<PaymentModel> itemsList
        {
            get { return _itemsList; }
            set
            {
                _itemsList = value;
                OnPropertyChanged();
            }
        }
        private IAllDataServices _IAllDataServices;
        ObservableCollection<PaymentModel> _itemsList;

        public PaymentViewModelcs() {
            _IAllDataServices = new AllDataServices();
        }
        public async void initialiseList()
        {
            var Wait = UserDialogs.Instance.Loading("Wait...", Cancel(), "", true, MaskType.Black);
            Wait.Show();
            try
            {
                
                JObject result = await _IAllDataServices.getChannelPartnerPayment(CPSettings.ChannelPartnerid) as JObject;
                if (result != null)
                {
                    var type = (int)result["Type"];
                    if (type == 1)
                    {
                        itemsList = JsonConvert.DeserializeObject<ObservableCollection<PaymentModel>>(result["Result"].ToString());
                        if (itemsList.Count == 0)
                        {
                            await App.Current.MainPage.DisplayAlert("Oops!", "No Payment detail found.", "Ok");


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
