using System;
using System.Collections.ObjectModel;
using System.Threading;
using Acr.UserDialogs;
using ChannelPartner.Models;
using ChannelPartner.Services;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ChannelPartner.ViewModels
{
    public class FranchiseeDetailsViewModel: BaseViewModel
    {
        ObservableCollection<TransactionItem> _items;
        public ObservableCollection<TransactionItem> Items { get { return _items; } set { _items = value; OnPropertyChanged(); } }

        private FranchiseeFullDetailModel _detailModel;
        public FranchiseeFullDetailModel DetailModel { get { return _detailModel; } set { _detailModel = value;OnPropertyChanged(); } }
        private IAllDataServices _IAllDataServices;
        private string frID;

        private string _strCommissionPer;
        public string StrCommisionPercent { get { return _strCommissionPer; } set { _strCommissionPer = value; OnPropertyChanged(); } }

        bool _isLeadger;
        public bool isLeadgerView { get { return _isLeadger; } set { _isLeadger = value;OnPropertyChanged(); } }
        bool _isList;
        public bool isListView { get { return _isList; } set { _isList = value; OnPropertyChanged(); } }

        public FranchiseeDetailsViewModel(string franchiseID)
        {
            StrCommisionPercent = "0.0";
            DetailModel = new FranchiseeFullDetailModel();
            _IAllDataServices = new AllDataServices();
            frID = franchiseID;
            isLeadgerView = true;
            isListView = false;
        }
        public async void getDetailsFromServer()
        {
            var Wait = UserDialogs.Instance.Loading("Wait...", Cancel(), "", true, MaskType.Black);
            Wait.Show();
            try
            {

                JObject result = await _IAllDataServices.GetFranchiseDetailByFranchiseId(frID) as JObject;
                if (result != null)
                {
                    var type = (int)result["Type"];
                    if (type == 1)
                    {
                        DetailModel = JsonConvert.DeserializeObject<FranchiseeFullDetailModel>(result["Result"].ToString());
                        if (DetailModel!= null)
                        {
                            initialiseList();


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
        public async void initialiseList()
        {
            var Wait = UserDialogs.Instance.Loading("Wait...", Cancel(), "", true, MaskType.Black);
            Wait.Show();
            try
            {

                JObject result = await _IAllDataServices.GetLedgerByFranchiseId(frID) as JObject;
                if (result != null)
                {
                    var type = (int)result["Type"];
                    if (type == 1)
                    {
                        Items = JsonConvert.DeserializeObject<ObservableCollection<TransactionItem>>(result["Result"].ToString());
                        if (Items.Count == 0)
                        {
                            await App.Current.MainPage.DisplayAlert("Oops!", "No Transactions found.", "Ok");


                        }
                        else {

                            StrCommisionPercent = Items[0].CommissionPercentage;
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
