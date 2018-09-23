using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using SmartHome.Interfaces;
using Xamarin.Forms;

namespace SmartHome.ViewModels
{
    class StartPageViewModel : BaseViewModel
    {
        public ICommand Command_BondedDevices { get; set; }
        public ICommand Command_SearchDevices { get; set; }

        public StartPageViewModel(IPageService pageService) : base(pageService)
        {
            Command_BondedDevices = new Command(async () => await base._pageService.NavigationPushAsync(new ConnectionPage()));
            Command_SearchDevices = new Command(async () => await base._pageService.NavigationPushAsync(new ConnectionPage()));
        }


    }
}
