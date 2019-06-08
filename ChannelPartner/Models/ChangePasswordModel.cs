using System;
using System.Collections.Generic;
using System.Text;

namespace ChannelPartner.Models
{
   public class ChangePasswordModel
    {
       public string oldPassword { get; set; }
       public string ChannelPartnerid { get; set; }
       public string newPassword { get; set; }
    }
}
