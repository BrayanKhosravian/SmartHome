using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartHome.Services;
using SmartHome.ViewModels;
using Xamarin.Forms;

namespace SmartHome
{
    public partial class OptionPage : ContentPage
    {
        public OptionPage()
        {
            InitializeComponent();

            PageService pageService = new PageService(this);
            BindingContext = new OptionPageViewModel(pageService);
        }

    }
}
