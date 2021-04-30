using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OscilloscopePCSide.Services
{
    public interface ISerialPortListProviderService
    {
        event EventHandler<EventArgs> SerialPortListUpdated;

        void Start();

        IList<SerialPortInfo> GetSerialPortInfos();
    }

    public class SerialPortInfo
    {
        public string Name { get; }
        
        public string Description { get; }

        public string NameAndDescription
        {
            get
            {
                return Name + " - " + Description;
            }
        }

        public SerialPortInfo(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}
