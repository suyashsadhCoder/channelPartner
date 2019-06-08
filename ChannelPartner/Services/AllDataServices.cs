using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using ChannelPartner.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Plugin.Connectivity;
using Xamarin.Forms;

namespace ChannelPartner.Services
{
    public class AllDataServices : IAllDataServices
    {
        
         string Baseurl = "http://msit.satisfactionwebsolution.in/";
       // string Baseurl = "http://dev.setquestionpaper.com/";
        private bool CheckConnection()
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public async Task<JObject> CheckLoginAsync(AppLoginClass _AppLoginClass)
        {

            if (CheckConnection())
            {
                using (var client = new HttpClient())
                {
                    string url = Baseurl + "API/api/ChannelPartnerApi/CheckChannelPartnerLogin";
                    client.BaseAddress = new Uri(Baseurl);

                    client.DefaultRequestHeaders.Clear();

                    client.DefaultRequestHeaders.ExpectContinue = false;
                    //Define request data format  
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var jsonRequest = JsonConvert.SerializeObject(_AppLoginClass);

                    var content = new StringContent(jsonRequest, null, "application/json");
                    HttpResponseMessage Res = null;
                    Res = await client.PostAsync(url, content);
                    JObject results = new JObject();
                    if (Res.IsSuccessStatusCode)
                    {
                        var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                        results = JObject.Parse(EmpResponse);
                    }
                    return results;
                }
            }
            else
            {
                JObject jb = new JObject();
                jb.Add("Type", "-1");
                jb.Add("ResponseMessage", " Network not available. Please check your  internet connection and try again..... ");
                return jb;
            }
        }

        public async Task<JObject> GetFranchiseByChannelPartnerId(string channnelPartnerID)
        {
            if (CheckConnection())
            {
                using (var client = new HttpClient())
                {
                    string url = Baseurl + "API/api/ChannelPartnerApi/GetFranchiseByChannelPartnerId?SearchBy=&CurrentPage=1&PageSize=10&SortDirection=ASC&SortExpression=FranchiseName&ChannelPartnerId=" + channnelPartnerID;
                    client.BaseAddress = new Uri(Baseurl);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                    HttpResponseMessage Res = await client.GetAsync(url);
                    JObject results = new JObject();
                    if (Res.IsSuccessStatusCode)
                    {
                        var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                        results = JObject.Parse(EmpResponse);
                    }
                    return results;
                }
            }
            else
            {
                JObject jb = new JObject();

                jb.Add("Type", "0");
                jb.Add("ResponseMessage", " Network not available. Please check your  internet connection and try again..... ");

                return jb;
            }
        }

        public async Task<JObject> GetFranchiseDetailByFranchiseId(string franchiseId)
        {
            if (CheckConnection())
            {
                using (var client = new HttpClient())
                {
                    string url = Baseurl + "API/api/ChannelPartnerApi/GetFranchiseDetailByFranchiseId?FranchiseId=" + franchiseId+ "&ChannelPartnerId=" + CPSettings.ChannelPartnerid ;
                    client.BaseAddress = new Uri(Baseurl);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                    HttpResponseMessage Res = await client.GetAsync(url);
                    JObject results = new JObject();
                    if (Res.IsSuccessStatusCode)
                    {
                        var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                        results = JObject.Parse(EmpResponse);
                    }
                    return results;
                }
            }
            else
            {
                JObject jb = new JObject();

                jb.Add("Type", "0");
                jb.Add("ResponseMessage", " Network not available. Please check your  internet connection and try again..... ");

                return jb;
            }
        }

        public async Task<JObject> GetLedgerByFranchiseId(string franchiseId)
        {
            if (CheckConnection())
            {
                using (var client = new HttpClient())
                {
                    string url = Baseurl + "API/api/ChannelPartnerApi/GetLedgerByFranchiseId?FranchiseId=" + franchiseId + "&ChannelPartnerId=" + CPSettings.ChannelPartnerid ;
                    client.BaseAddress = new Uri(Baseurl);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                    HttpResponseMessage Res = await client.GetAsync(url);
                    JObject results = new JObject();
                    if (Res.IsSuccessStatusCode)
                    {
                        var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                        results = JObject.Parse(EmpResponse);
                    }
                    return results;
                }
            }
            else
            {
                JObject jb = new JObject();

                jb.Add("Type", "0");
                jb.Add("ResponseMessage", " Network not available. Please check your  internet connection and try again..... ");

                return jb;
            }
        }

        public async Task<JObject> UpdateChannelPartnerPassword(ChangePasswordModel model)
        {
            if (CheckConnection())
            {
                using (var client = new HttpClient())
                {
                    string url = Baseurl + "API/api/ChannelPartnerApi/UpdateChannelPartnerPassword";
                    client.BaseAddress = new Uri(Baseurl);

                    client.DefaultRequestHeaders.Clear();

                    client.DefaultRequestHeaders.ExpectContinue = false;
                    //Define request data format  
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var jsonRequest = JsonConvert.SerializeObject(model);

                    var content = new StringContent(jsonRequest, null, "application/json");
                    HttpResponseMessage Res = null;
                    Res = await client.PostAsync(url, content);
                    JObject results = new JObject();
                    if (Res.IsSuccessStatusCode)
                    {
                        var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                        results = JObject.Parse(EmpResponse);
                    }
                    return results;
                }
            }
            else
            {
                JObject jb = new JObject();
                jb.Add("Type", "-1");
                jb.Add("ResponseMessage", " Network not available. Please check your  internet connection and try again..... ");
                return jb;
            }
        }

        public async Task<JObject> UpdateChannelPartnerProfile(UpdateProfileModel model)
        {
            if (CheckConnection())
            {
                using (var client = new HttpClient())
                {
                    string url = Baseurl + "API/api/ChannelPartnerApi/UpdateChannelPartnerProfile";
                    client.BaseAddress = new Uri(Baseurl);

                    client.DefaultRequestHeaders.Clear();

                    client.DefaultRequestHeaders.ExpectContinue = false;
                    //Define request data format  
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var jsonRequest = JsonConvert.SerializeObject(model);

                    var content = new StringContent(jsonRequest, null, "application/json");
                    HttpResponseMessage Res = null;
                    Res = await client.PostAsync(url, content);
                    JObject results = new JObject();
                    if (Res.IsSuccessStatusCode)
                    {
                        var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                        results = JObject.Parse(EmpResponse);
                    }
                    return results;
                }
            }
            else
            {
                JObject jb = new JObject();
                jb.Add("Type", "-1");
                jb.Add("ResponseMessage", " Network not available. Please check your  internet connection and try again..... ");
                return jb;
            }
        }

        public async Task<JObject> getChannelPartnerPayment(string channnelPartnerID)
        {
            if (CheckConnection())
            {
                using (var client = new HttpClient())
                {
                    string url = Baseurl + "API/api/ChannelPartnerApi/getChannelPartnerPayment?ChannelPartnerId=" + channnelPartnerID;
                    client.BaseAddress = new Uri(Baseurl);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                    HttpResponseMessage Res = await client.GetAsync(url);
                    JObject results = new JObject();
                    if (Res.IsSuccessStatusCode)
                    {
                        var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                        results = JObject.Parse(EmpResponse);
                    }
                    return results;
                }
            }
            else
            {
                JObject jb = new JObject();

                jb.Add("Type", "0");
                jb.Add("ResponseMessage", " Network not available. Please check your  internet connection and try again..... ");

                return jb;
            }

        }

        public async Task<JObject> GetFranchiseByChannelPartnerId(FranciseSearchFilter filter)
        {
            if (CheckConnection())
            {
                using (var client = new HttpClient())
                {
                    string url = Baseurl + "API/api/ChannelPartnerApi/GetFranchiseByChannelPartnerId?SearchBy="+filter.SearchBy
                        +"&CurrentPage="+filter.CurrentPage+"&PageSize="+filter.PageSize+"&SortDirection="+filter.SortDirection+"&SortExpression="+filter.SortExpression
                        +"&ChannelPartnerId=" + filter.ChannelPartnerId;
                    client.BaseAddress = new Uri(Baseurl);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                    HttpResponseMessage Res = await client.GetAsync(url);
                    JObject results = new JObject();
                    if (Res.IsSuccessStatusCode)
                    {
                        var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                        results = JObject.Parse(EmpResponse);
                    }
                    return results;
                }
            }
            else
            {
                JObject jb = new JObject();

                jb.Add("Type", "0");
                jb.Add("ResponseMessage", " Network not available. Please check your  internet connection and try again..... ");

                return jb;
            }
        }

        public async Task<JObject> getChannelPartnerDashboard(string channnelPartnerID)
        {
            if (CheckConnection())
            {
                using (var client = new HttpClient())
                {
                    string url = Baseurl + "API/api/ChannelPartnerApi/getdashboard?ChannelPartnerId=" + CPSettings.ChannelPartnerid;
                    client.BaseAddress = new Uri(Baseurl);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                    HttpResponseMessage Res = await client.GetAsync(url);
                    JObject results = new JObject();
                    if (Res.IsSuccessStatusCode)
                    {
                        var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                        results = JObject.Parse(EmpResponse);
                    }
                    return results;
                }
            }
            else
            {
                JObject jb = new JObject();

                jb.Add("Type", "0");
                jb.Add("ResponseMessage", " Network not available. Please check your  internet connection and try again..... ");

                return jb;
            }
        }

        public async Task<JObject> getForgetPassword(string mobileNo)
        {
            if (CheckConnection())
            {
                using (var client = new HttpClient())
                {
                    string url = Baseurl + "API/api/ChannelPartnerApi/forgetpassword?mobileNumber=" + mobileNo;
                    client.BaseAddress = new Uri(Baseurl);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                    HttpResponseMessage Res = await client.GetAsync(url);
                    JObject results = new JObject();
                    if (Res.IsSuccessStatusCode)
                    {
                        var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                        results = JObject.Parse(EmpResponse);
                    }
                    return results;
                }
            }
            else
            {
                JObject jb = new JObject();

                jb.Add("Type", "0");
                jb.Add("ResponseMessage", " Network not available. Please check your  internet connection and try again..... ");

                return jb;
            }
        }

        public async Task<JObject> FranchiseRegistration(FranchiseMasters franchiseMasters_Classs)
        {
            if (CheckConnection())
            {
                using (var client = new HttpClient())
                {
                    string url = Baseurl + "/API/Api/FranchiseRegistrationApi/SaveFranchise";
                    client.BaseAddress = new Uri(Baseurl);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.ExpectContinue = false;
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Add("Key", Application.Current.Properties["Key"].ToString());
                    client.DefaultRequestHeaders.Add("UserName", Application.Current.Properties["UserName"].ToString());
                    client.DefaultRequestHeaders.Add("Password", Application.Current.Properties["Password"].ToString());
                    var jsonRequest = JsonConvert.SerializeObject(franchiseMasters_Classs);
                    var content = new StringContent(jsonRequest, null, "application/json");
                    HttpResponseMessage Res = null;
                    Res = await client.PostAsync(url, content);
                    JObject results = new JObject();
                    if (Res.IsSuccessStatusCode)
                    {
                        var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                        results = JObject.Parse(EmpResponse);
                    }
                    return results;
                }

            }
            else
            {
                JObject jb = new JObject();

                jb.Add("Type", "0");
                jb.Add("ResponseMessage", " Network not available. Please check your  internet connection and try again..... ");

                return jb;
            }
        }

        public async Task<JObject> GetStateAndCity()
        {
            if (CheckConnection())
            {
                //var Wait = UserDialogs.Instance.Loading("Loading", null, null, true, MaskType.Black);
                //Wait.Show();
                using (var client = new HttpClient())
                {
                    string url = Baseurl+"/API/api/CityApi/GetCity";
                    client.BaseAddress = new Uri(Baseurl);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage Res = await client.GetAsync(url);
                    JObject results = new JObject();
                    if (Res.IsSuccessStatusCode)
                    {
                        var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                        results = JObject.Parse(EmpResponse);
                    }
                    
                    return results;
                }
            }
            else
            {
                JObject jb = new JObject();

                jb.Add("Type", "0");
                jb.Add("ResponseMessage", " Network not available. Please check your  internet connection and try again..... ");

                return jb;
            }
        }
    }
}
