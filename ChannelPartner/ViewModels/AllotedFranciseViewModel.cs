using System;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;
using Acr.UserDialogs;
using ChannelPartner.Models;
using ChannelPartner.Services;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xamarin.Forms;

namespace ChannelPartner.ViewModels
{
    public class AllotedFranciseViewModel : BaseViewModel
    {
        public ObservableCollection<FranchiseeDetailModel> itemsList
        {
            get { return _itemsList; }
            set {
                _itemsList = value;
                OnPropertyChanged();
            }
        }
        private IAllDataServices _IAllDataServices;
        ObservableCollection<FranchiseeDetailModel> _itemsList;
        public AllotedFranciseViewModel()
        {
            _IAllDataServices = new AllDataServices();
        }
        public async void initialiseList() {
            var Wait = UserDialogs.Instance.Loading("Wait...", Cancel(), "", true, MaskType.Black);
            Wait.Show();
            try
            {
                
                JObject result = await _IAllDataServices.GetFranchiseByChannelPartnerId(CPSettings.ChannelPartnerid) as JObject;
                if (result != null)
                {
                    var type = (int)result["Type"];
                    if (type == 1)
                    {
                        itemsList = JsonConvert.DeserializeObject<ObservableCollection<FranchiseeDetailModel>>(result["Result"].ToString());
                        if (itemsList.Count == 0)
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
        public async Task<ObservableCollection<FranchiseeDetailModel>> LoadListWithFilter(FranciseSearchFilter model)
        {
            try
            {
                JObject result = await _IAllDataServices.GetFranchiseByChannelPartnerId(model) as JObject;
                if (result != null)
                {
                    var type = (int)result["Type"];
                    if (type == 1)
                    {
                        var list = JsonConvert.DeserializeObject<ObservableCollection<FranchiseeDetailModel>>(result["Result"].ToString());
                        if (list.Count > 0)
                        {

                            return list;

                        }
                        else { return new ObservableCollection<FranchiseeDetailModel>(); }

                    }
                    else
                    {
                        return new ObservableCollection<FranchiseeDetailModel>();
                    }



                }
                else { return new ObservableCollection<FranchiseeDetailModel>(); }
               
            }
            catch (Exception e)
            {
                return new ObservableCollection<FranchiseeDetailModel>();
            }


        }

    }
}
