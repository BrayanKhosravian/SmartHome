using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Bluetooth;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SmartHome.Droid.Services;
using SmartHome.Interfaces;
using Xamarin.Forms;

[assembly: Dependency(typeof(BluetoothController))]

namespace SmartHome.Droid.Services
{
    class BluetoothController : BluetoothCore, IBluetoothController
    {
        public BluetoothController()
        {
            
        }

        public Dictionary<string, string> GetBondedDevices()
        {
            while (!base.BtAdapter.IsEnabled)       // wait till bt adapter is enabled
            {
                base.BtAdapter.Enable();
            }

            ICollection<BluetoothDevice> devices = base.BtAdapter.BondedDevices;
            Dictionary<string, string> dictionary = new Dictionary<string, string>();

            foreach (BluetoothDevice device in devices)
            {
                dictionary.Add(device.Name, device.Address);
            }

            return dictionary;
        }

        public bool ConnectTo(string mac, string uuid = null)
        {
            BluetoothDevice btDevice = base.TryGetDevice(mac);
            BluetoothSocket btSocket = base.TryGetSocket(btDevice);

            try
            {
                btSocket?.Connect();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }

        }

        public void SendData(string data)
        {
                     
        }
    }
}