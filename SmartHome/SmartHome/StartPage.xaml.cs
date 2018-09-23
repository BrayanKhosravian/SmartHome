using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartHome.Services;
using SmartHome.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SmartHome
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class StartPage : ContentPage
	{
		public StartPage ()
		{
			InitializeComponent ();

            PageService pageService = new PageService(this);
		    BindingContext = new StartPageViewModel(pageService);
		}
    }
}