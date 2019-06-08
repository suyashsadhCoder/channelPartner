using ChannelPartner.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ChannelPartner.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ForgetPasswordView : ContentPage
	{

        public ForgetPasswordViewModel viewModel;
        public ForgetPasswordView ()
		{
			InitializeComponent ();
            this.BindingContext = viewModel = new ForgetPasswordViewModel(Navigation);
            crossButton.Clicked += CrossButton_Clicked;
        }
        private void CrossButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }
    }
}