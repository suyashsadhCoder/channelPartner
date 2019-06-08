using System;
using System.Collections.Generic;
using System.Text;
using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace ChannelPartner.Models
{
    public static class CPSettings
    {
        private static ISettings AppSettings
        {
            get
            {
                return CrossSettings.Current;
            }
        }

       

        
        private static readonly string SettingsDefault = string.Empty;

        private const string kChannelPartnerid = "ChannelPartnerid";
        public static string ChannelPartnerid
        {
            get
            {
                return AppSettings.GetValueOrDefault(kChannelPartnerid, SettingsDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(kChannelPartnerid, value);
            }
        }
        private const string kChannelPartnerName = "ChannelPartnerName";
        public static string ChannelPartnerName
        {
            get
            {
                return AppSettings.GetValueOrDefault(kChannelPartnerName, SettingsDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(kChannelPartnerName, value);
            }
        }
        private const string kMobileNumber = "MobileNumber";
        public static string MobileNumber
        {
            get
            {
                return AppSettings.GetValueOrDefault(kMobileNumber, SettingsDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(kMobileNumber, value);
            }
        }
        private const string kEmailId = "EmailId";
        public static string EmailId
        {
            get
            {
                return AppSettings.GetValueOrDefault(kEmailId, SettingsDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(kEmailId, value);
            }
        }

    }
}
