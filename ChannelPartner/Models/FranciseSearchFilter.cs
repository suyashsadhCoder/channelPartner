using System;
using System.Collections.Generic;
using System.Text;

namespace ChannelPartner.Models
{
   public class FranciseSearchFilter
    {
        public string SearchBy { get; set; }
        public string CurrentPage { get; set; }
        public string PageSize { get; set; }
        public string SortDirection { get; set; }
        public string SortExpression { get; set; }
        public string FranchiseName { get; set; }
        public string ChannelPartnerId { get; set; }
    }
}
