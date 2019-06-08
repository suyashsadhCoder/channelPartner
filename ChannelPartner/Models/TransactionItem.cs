using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace ChannelPartner.Models
{
   public class TransactionItem
    {
        public string yearNum { get; set; }
        public string _monthName { get; set; }
        public string slab { get; set; }
        public string sellAmount { get; set; }
        public string franchisePaidStatus { get; set; }
        public string CpPaidStatus { get; set; }
        public string CommissionPercentage { get; set; }
        public string DueDate { get; set; }

        public string monthYear { get { return _monthName + " " + yearNum; } }
        public string strsellAmount
        {
            get
            {
                decimal parsed = decimal.Parse(sellAmount != null ? sellAmount : "0", CultureInfo.InvariantCulture);
                CultureInfo hindi = new CultureInfo("hi-IN");
                return string.Format(hindi, "{0:c}", parsed);
            }
        }
    }
}
