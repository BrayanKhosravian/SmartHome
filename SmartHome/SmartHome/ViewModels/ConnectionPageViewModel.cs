using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using SmartHome.Interfaces;
using SmartHome.Models;
using Xamarin.Forms;

namespace SmartHome.ViewModels
{
    class ConnectionPageViewModel : BaseViewModel
    {
        public ObservableCollection<CustomBluetoothDevice> Items { get; private set; } = new ObservableCollection<CustomBluetoothDevice>();

        // ctor
        public ConnectionPageViewModel(IPageService pageService) : base(pageService)
        {
            CreateListView();
        }

        public async Task ItemTapped(CustomBluetoothDevice device)
        {
            IsSelected = new object();
            base.IsBusy = true;

            if (device == null)
            {
                base.IsSelected = null;
                base.IsBusy = false;
                return;
            }

            // bool isConnected = ((App) (Application.Current)).BluetoothController.ConnectTo(device?.Mac);
             bool isConnected = DependencyService.Get<IBluetoothController>().ConnectTo(device?.Mac);

            if (isConnected)
            {
                base.IsBusy = false;
                base.IsSelected = null;
                await _pageService.DisplayAlert("State", "Device connected", "ok");
                await _pageService.NavigationPushAsync(new OptionPage());
            }
            else await _pageService.DisplayAlert("State", "Device failed to connect", "ok");

            base.IsBusy = false;
            base.IsSelected = null;
            
        }

        private void CreateListView()
        {
            
           // var devices = ((App) Application.Current).BluetoothController.GetBondedDevices();
            var devices = DependencyService.Get<IBluetoothController>().GetBondedDevices();
            foreach (var device in devices)
            {
                Items.Add(new CustomBluetoothDevice(device.Key, device.Value));
            }
            
        }



    }
}
