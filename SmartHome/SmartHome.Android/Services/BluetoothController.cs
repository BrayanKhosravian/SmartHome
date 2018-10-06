using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Android.App;
using Android.Bluetooth;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Java.Util;
using SmartHome.Droid.Services;
using SmartHome.Interfaces;
using Xamarin.Forms;

[assembly: Dependency(typeof(BluetoothController))]

namespace SmartHome.Droid.Services
{
    class BluetoothController : IBluetoothController
    {
        private static readonly BluetoothAdapter _btAdapter = BluetoothAdapter.DefaultAdapter;      // IDisposeable
        private static BluetoothSocket _btSocket;                                            // IDisposeable
        private BluetoothDevice _btDevice;                                                      // IDisposeable

        public BluetoothController()    // parameterless ctor for dependency service
        {
            
        }

        public Dictionary<string, string> GetBondedDevices()
        {
            while (!_btAdapter.IsEnabled) // wait till bluetooth is enabled
            {
                _btAdapter.Enable();
            }

            ICollection<BluetoothDevice> devices = _btAdapter.BondedDevices;
            Dictionary<string, string> dictionary = new Dictionary<string, string>();

            foreach (BluetoothDevice device in devices)
            {
                dictionary.Add(device.Name, device.Address);
            }

            return dictionary;
        }

        public bool ConnectTo(string mac, string uuid = null)
        {
             _btDevice = this.TryGetDevice(mac);
             _btSocket = this.TryGetSocket(_btDevice);

            try
            {
                _btSocket?.Connect();
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
            byte[] msgBuffer = Encoding.ASCII.GetBytes(data);

            try
            {
                if (_btSocket == null) return;
                Stream outStream = _btSocket.OutputStream;
                outStream.Write(msgBuffer, 0, msgBuffer.Length);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            
        }

        private BluetoothDevice TryGetDevice(string mac)
        {
            bool isMac = BluetoothAdapter.CheckBluetoothAddress(mac);
            if (isMac)
            {
                return _btAdapter.GetRemoteDevice(mac);
            }
            else
            {
                return null;
            }
        }

        private BluetoothSocket TryGetSocket(BluetoothDevice bluetoothDevice, string uuid = null)
        {
            UUID id = UUID.FromString(uuid ?? "00001101-0000-1000-8000-00805F9B34FB");

            try
            {
                _btSocket = bluetoothDevice?.CreateRfcommSocketToServiceRecord(id);       // Secure Socket
                return _btSocket;
            }
            catch (Exception e1)
            {
                Console.WriteLine(e1);

                try
                {
                    _btSocket = bluetoothDevice?.CreateInsecureRfcommSocketToServiceRecord(id);       // Insecure Socket
                    return _btSocket;
                }
                catch (Exception e2)
                {
                    Console.WriteLine(e2);
                    _btSocket?.Dispose();
                    return null;
                }
            }
        }

    }
}