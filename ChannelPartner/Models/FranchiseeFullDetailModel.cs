using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace ChannelPartner.Models
{
   public class FranchiseeFullDetailModel
    {
        public string FranchiseId { get; set; }
        public string FranchiseName { get; set; }
        public string FranchiseOwnerName { get; set; }
        public string FranchiseAddress { get; set; }
        public string FranchisePermanentAddress { get; set; }
        public string FranchiseEmailId { get; set; }
        public string FranchisePrimaryMobileNo { get; set; }
        public string FranchiseAlternateMobileNo { get; set; }
        public string CityName { get; set; }
        public string StateName { get; set; }
        public string FranchisePhoto { get; set; }
        public string DueDate { get; set; }
        public string FranchiseCode { get; set; }
        public string FranchiseLatitude { get; set; }
        public string FranchiseLongitude { get; set; }
        public string FranchisePinCode { get; set; }
        public string TotalRemainingStock { get; set; }
        public string TotalDueAmount { get; set; }
        public string TotalPendingCommission { get; set; }
        public string CommissionPercentage { get; set; }

        public string strDueDate { get { return System.DateTime.Parse(DueDate!=null?DueDate:System.DateTime.Now.ToString()).ToString("dd/MM/yyyy"); } }


        public string PhotoURL { get { return "" + FranchisePhoto; } }
        public string strTotalRemaningStock {
            get {
                decimal parsed = decimal.Parse(TotalRemainingStock != null ? TotalRemainingStock : "0", CultureInfo.InvariantCulture);
                CultureInfo hindi = new CultureInfo("hi-IN");
                return string.Format(hindi, "{0:c}", parsed);
            }
        }
        public string strTotalDueAmount
        {
            get
            {
                decimal parsed = decimal.Parse(TotalDueAmount != null ? TotalDueAmount : "0", CultureInfo.InvariantCulture);
                CultureInfo hindi = new CultureInfo("hi-IN");
                return string.Format(hindi, "{0:c}", parsed);
            }
        }
        public string strTotalPendingCommission
        {
            get
            {
                decimal parsed = decimal.Parse(TotalPendingCommission != null ? TotalPendingCommission : "0", CultureInfo.InvariantCulture);
                CultureInfo hindi = new CultureInfo("hi-IN");
                return string.Format(hindi, "{0:c}", parsed);
            }
        }


    }
}
