using System;
using System.Collections.Generic;
using System.Text;

namespace SmartHome.Models
{
    public class CustomBluetoothDevice
    {
        public string Name { get; set; }
        public string Mac { get; set; }

        public CustomBluetoothDevice(string name, string mac)
        {
            Name = name;
            Mac = mac;
        }
    }
}
