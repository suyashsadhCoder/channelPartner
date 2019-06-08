using ChannelPartner.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ChannelPartner.Services
{
    public interface IAllDataServices
    {
        Task<JObject> CheckLoginAsync(AppLoginClass _AppLoginClass);
        Task<JObject> GetFranchiseByChannelPartnerId(string channnelPartnerID);
        Task<JObject> GetFranchiseByChannelPartnerId(FranciseSearchFilter filter);
        Task<JObject> GetFranchiseDetailByFranchiseId(string franchiseId);
        Task<JObject> GetLedgerByFranchiseId(string franchiseId);
        Task<JObject> UpdateChannelPartnerPassword(ChangePasswordModel model);
        Task<JObject> UpdateChannelPartnerProfile(UpdateProfileModel model);
        Task<JObject> getChannelPartnerPayment(string channnelPartnerID);
        Task<JObject> getChannelPartnerDashboard(string channnelPartnerID);
        Task<JObject> getForgetPassword(string mobileNo);
        Task<JObject> FranchiseRegistration(FranchiseMasters franchiseMasters_Classs);
        Task<JObject> GetStateAndCity();
    }
}
