using System.Collections.Generic;
using System.Dynamic;
using SmartHome.Models;

namespace SmartHome.Interfaces
{
    public interface IBluetoothController
    {
        Dictionary<string, string> GetBondedDevices();
        bool ConnectTo(string mac, string uuid = null);

        void SendData(string data);
    }

    
}