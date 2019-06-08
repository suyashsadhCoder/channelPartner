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
	public partial class HomeView : ContentPage
	{

        HomeViewModel viewModel;
		public HomeView ()
		{
			InitializeComponent ();
            this.BindingContext = viewModel = new HomeViewModel();
		}
	}
}