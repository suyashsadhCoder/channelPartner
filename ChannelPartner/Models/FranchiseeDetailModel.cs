using System;
using System.Globalization;

namespace ChannelPartner.Models
{
    public class FranchiseeDetailModel
    {
        public string Sno { get; set; }
        public string DueAmount { get; set; }
        public string franchiseId { get; set; }
        public string FranchiseName { get; set; }
        public string FranchiseCode { get; set; }
        public string DueDate { get; set; }
        public string PendingCommissionAmount { get; set; }
        public string FranchisePayStatus { get; set; }
        public string StrDueDate { get { return DateTime.Parse(DueDate).ToString("dd/MM/yyyy");  } }
        public string StrDueAmount { get
            {
                decimal parsed = decimal.Parse(DueAmount!=null? DueAmount:"0", CultureInfo.InvariantCulture);
                CultureInfo hindi = new CultureInfo("hi-IN");
                return string.Format(hindi, "{0:c}", parsed);
            }
        }
        public string StrPendingCommissionAmount { get
            {
                decimal parsed = decimal.Parse(PendingCommissionAmount!=null?PendingCommissionAmount:"0", CultureInfo.InvariantCulture);
                CultureInfo hindi = new CultureInfo("hi-IN");
                return string.Format(hindi, "{0:c}", parsed);
            }
        }
        public string textColorAmount { get { return FranchisePayStatus == "PAID" ? "Green" : "Yellow"; } }

    }
}
