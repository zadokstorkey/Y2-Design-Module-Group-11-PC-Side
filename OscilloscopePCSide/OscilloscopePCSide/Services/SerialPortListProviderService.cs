using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace OscilloscopePCSide.Services
{
    public class SerialPortListProviderService : ISerialPortListProviderService
    {
        public event EventHandler<EventArgs> SerialPortListUpdated;

        public void Start()
        {
            ManagementEventWatcher managementEventWatcher = new ManagementEventWatcher();
            managementEventWatcher.Query = new WqlEventQuery("SELECT * FROM Win32_VolumeChangeEvent WHERE EventType = 2");
            managementEventWatcher.EventArrived += ManagementEventWatcher_EventArrived;
            managementEventWatcher.Start();
        }

        public IList<SerialPortInfo> GetSerialPortInfos()
        {
            var serialPortInfos = new List<SerialPortInfo>();
            ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("Select * From Win32_SerialPort");
            ManagementObjectCollection managementObjectCollection = managementObjectSearcher.Get();
            foreach (ManagementObject managementObject in managementObjectCollection)
            {
                serialPortInfos.Add(new SerialPortInfo((string)managementObject["DeviceID"], (string)managementObject["Description"]));
            }
            return serialPortInfos;
        }

        private void ManagementEventWatcher_EventArrived(object sender, EventArrivedEventArgs e)
        {
            SerialPortListUpdated.Invoke(this, new EventArgs());
        }
    }
}
