using System;
using System.Collections.Generic;
using System.Text;

namespace ChannelPartner.Models
{
    public class MultipleContect_Class
    {
        string ContactNo = string.Empty;
        public string Contect_No
        {
            get { return ContactNo; }
            set
            {
                ContactNo = value;
                if (12 >= value.Length && value.Length >= 10)
                {
                    ErrorMessageStatus = false;
                }
                else if (value.Length == 0)
                {
                    ErrorMessageStatus = false;
                }
                else
                {
                    ErrorMessageStatus = true;
                }

            }
        }
        //public string ErrorMessage { get { return "minimumLength 10 and maximumLength 12 required"; } }
        public bool ErrorMessageStatus
        {
            get;
            set;
        }
    }
}
