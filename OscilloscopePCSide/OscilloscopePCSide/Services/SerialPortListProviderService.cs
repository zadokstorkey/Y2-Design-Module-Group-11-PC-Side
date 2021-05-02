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
        private bool _mostRecentSerialPortInfosAreUpToDate = false;

        private IList<SerialPortInfo> _mostRecentSerialPortInfos;

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
            if (_mostRecentSerialPortInfosAreUpToDate)
            {
                return _mostRecentSerialPortInfos;
            }
            else
            {
                var serialPortInfos = new List<SerialPortInfo>();
                ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("Select * From Win32_SerialPort");
                ManagementObjectCollection managementObjectCollection = managementObjectSearcher.Get();
                foreach (ManagementObject managementObject in managementObjectCollection)
                {
                    serialPortInfos.Add(new SerialPortInfo((string)managementObject["DeviceID"], (string)managementObject["Description"]));
                }
                _mostRecentSerialPortInfos = serialPortInfos;
                _mostRecentSerialPortInfosAreUpToDate = true;
                return serialPortInfos;
            }
        }

        private void ManagementEventWatcher_EventArrived(object sender, EventArrivedEventArgs e)
        {
            _mostRecentSerialPortInfosAreUpToDate = false;
            SerialPortListUpdated.Invoke(this, new EventArgs());
        }
    }
}
