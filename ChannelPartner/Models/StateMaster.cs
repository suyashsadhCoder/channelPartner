using System;
using System.Collections.Generic;
using System.Text;

namespace ChannelPartner.Models
{
   public  class StateMaster
    {
        public int State_ID { get; set; }

        public string State_Name { get; set; }

        public List<CityMaster> CityClassList { get; set; }
    }
}
