using System.ComponentModel;
using SmartHome.Interfaces;
using SmartHome.Services;
using SmartHome.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SmartHome
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LightPage : ContentPage
	{
		public LightPage ()
		{
			InitializeComponent ();

            IPageService pageService = new PageService(this);
		    BindingContext = new LightPageViewModel(pageService);
		}
	}
}