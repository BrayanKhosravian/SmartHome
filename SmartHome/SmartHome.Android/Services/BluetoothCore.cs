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
using Java.Util;

namespace SmartHome.Droid.Services
{
    class BluetoothCore
    {
        public  BluetoothAdapter BtAdapter { get; } = BluetoothAdapter.DefaultAdapter;      // IDisposeable
        private BluetoothSocket _btSocket = null;                                            // IDisposeable

        public BluetoothDevice TryGetDevice(string mac)
        {
            bool isMac = BluetoothAdapter.CheckBluetoothAddress(mac);
            if (isMac)
            {
                 return BtAdapter.GetRemoteDevice(mac);
            }
            else
            {
                return null;
            }
        }

        public BluetoothSocket TryGetSocket(BluetoothDevice bluetoothDevice, string uuid = null)
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