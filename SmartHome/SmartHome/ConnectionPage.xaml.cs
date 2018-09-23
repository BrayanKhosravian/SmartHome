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
        public ObservableCollection<CustomBluetoothDevice> Items { get; set; } = new ObservableCollection<CustomBluetoothDevice>();

        public ConnectionPage()
        {
            InitializeComponent();

            IPageService pageService = new PageService(this);
            BindingContext = new ConnectionPageViewModel(pageService); 

            CreateListView();
			MyListView.ItemsSource = Items;
        }

        private void CreateListView()
        {
            var devices = DependencyService.Get<IBluetoothController>().GetBondedDevices();
            foreach (var device in devices)
            {
                Items.Add(new CustomBluetoothDevice(device.Key,device.Value));
            }
        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            ((ListView)sender).SelectedItem = null;     // Deselect Item

            var device = e.Item as CustomBluetoothDevice;
            bool isConnected = DependencyService.Get<IBluetoothController>().ConnectTo(device?.Mac);

            if (isConnected)
            {
                await DisplayAlert("State", "Device connected", "ok");
                await Navigation.PushAsync(new OptionPage());
            }
            else await DisplayAlert("State", "Device failed to connect", "ok");
           

        }
    }
}
