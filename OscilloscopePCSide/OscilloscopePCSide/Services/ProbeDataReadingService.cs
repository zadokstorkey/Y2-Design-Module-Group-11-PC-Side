using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OscilloscopePCSide.Services
{
    public class ProbeDataReadingService : IProbeDataReadingService
    {
        private readonly IProbeDataParsingService _probeDataParsingService;
        
        private readonly ISerialPortConnectionService _serialPortConnectionService;

        public IProbeDataParsingService ProbeDataParsingService
        {
            get
            {
                return this._probeDataParsingService;
            }
        }

        public ISerialPortConnectionService SerialPortConnectionService
        {
            get
            {
                return this._serialPortConnectionService;
            }
        }

        public void Start()
        {
            this._serialPortConnectionService.Connect();
            this._serialPortConnectionService.MessageReceived += OnSerialPortMessageReceived;
        }

        public void OnSerialPortMessageReceived(object sender, MessageReceivedEventArgs e)
        {
            var message = e.Message;
            var parsedMessage = _probeDataParsingService.ParseProbeData(message);
            
        }
    }
}
