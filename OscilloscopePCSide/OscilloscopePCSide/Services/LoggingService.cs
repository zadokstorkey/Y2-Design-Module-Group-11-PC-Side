using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OscilloscopePCSide.Services
{
    public class LoggingService : ILoggingService
    {
        private StreamWriter _rawCommunicationLogStream;
        private StreamWriter _communicationLogStream;

        public LoggingService()
        {
            _rawCommunicationLogStream = new StreamWriter("rawcommunication.log", false);
            _communicationLogStream = new StreamWriter("communication.log", false);
        }

        public void LogRawCommunication(string rawCommunication)
        {
            _rawCommunicationLogStream.Write(rawCommunication);
        }

        public void LogCommunication(string communication)
        {
            _communicationLogStream.WriteLine(communication);
            Trace.WriteLine(communication);
        }
    }
}
