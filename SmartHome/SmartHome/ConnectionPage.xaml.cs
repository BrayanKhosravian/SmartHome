using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using SmartHome.Interfaces;
using SmartHome.Models;
using SmartHome.Services;
using SmartHome.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SmartHome
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConnectionPage : ContentPage
    {

        public ConnectionPage()
        {
            InitializeComponent();

            IPageService pageService = new PageService(this);
            BindingContext = new ConnectionPageViewModel(pageService); 
        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            await (BindingContext as ConnectionPageViewModel)?.ItemTapped(e.Item as CustomBluetoothDevice);
        }

    }
}
