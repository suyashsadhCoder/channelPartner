using System;
using System.Collections.Generic;
using System.Text;

namespace ChannelPartner.Controls
{
   public interface IControlValidation
    {
        bool HasError { get; }
        string ErrorMessage { get; }
        bool ShowErrorMessage { get; set; }
    }
}
