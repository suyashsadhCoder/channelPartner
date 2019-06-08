using System;
using System.Collections.Generic;
using System.Text;

namespace ChannelPartner.Models
{
    public enum MenuItemType
    {
        Home,
        Franchise,
        NewFranchise,
        payments,
        Profile,
        changePassword
        
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }

        public string ImageName { get; set; }
    }
}
