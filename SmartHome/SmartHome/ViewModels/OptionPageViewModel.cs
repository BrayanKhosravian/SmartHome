using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using SmartHome.Interfaces;
using Xamarin.Forms;

namespace SmartHome.ViewModels
{
    class OptionPageViewModel : BaseViewModel
    {
        public ICommand Command_ToLightPage { get; private set; }

        public OptionPageViewModel(IPageService pageService) : base(pageService)
        {
            Command_ToLightPage = new Command(async () => await base._pageService.NavigationPushAsync(new LightPage()));
        }

    }
}
