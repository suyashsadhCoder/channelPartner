using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace ChannelPartner.Models
{
    public class PaymentModel
    {
        public string ChannelPartnerid { get; set; }
        public string ChannelPartnerName { get; set; }
        public string FranchiseName { get; set; }
        public string PaidType { get; set; }
        public string TermType { get; set; }
        public string TermDate { get; set; }
        public string TermMonth { get; set; }
        public string TermYear { get; set; }
        public string Amount { get; set; }
        public string Remark { get; set; }
        public string CreatedDate { get; set; }

        public string strTermDate { get { return DateTime.Parse(TermDate).ToString("dd/MM/yyyy"); } }
        public string strTermMonthYear { get { return TermMonth+"/"+ TermYear; } }
        public string strsellAmount
        {
            get
            {
                decimal parsed = decimal.Parse(Amount != null ? Amount : "0", CultureInfo.InvariantCulture);
                CultureInfo hindi = new CultureInfo("hi-IN");
                return string.Format(hindi, "{0:c}", parsed);
            }
        }
    }
}
