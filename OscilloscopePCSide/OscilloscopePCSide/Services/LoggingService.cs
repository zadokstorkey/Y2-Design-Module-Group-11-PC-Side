using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OscilloscopePCSide.Services
{
    public class LoggingService : ILoggingService
    {
        private bool _currentlyWritingRawCommunicationLog;
        private bool _currentlyWritingCommunicationLog;

        private StreamWriter _rawCommunicationLogStream;
        private StreamWriter _communicationLogStream;

        public LoggingService()
        {
            _rawCommunicationLogStream = new StreamWriter("rawcommunication.log", false);
            _communicationLogStream = new StreamWriter("communication.log", false);
        }

        public void LogRawCommunication(string rawCommunication)
        {
            // prevents to processes trying to write to the log at the same time
            while (_currentlyWritingRawCommunicationLog)
            {
                Thread.Yield();
            }

            _currentlyWritingRawCommunicationLog = true;
            _rawCommunicationLogStream.Write(rawCommunication);
            _currentlyWritingRawCommunicationLog = false;
        }

        public void LogCommunication(string communication)
        {
            // prevents to processes trying to write to the log at the same time
            while (_currentlyWritingCommunicationLog)
            {
                Thread.Yield();
            }

            _currentlyWritingCommunicationLog = true;
            _communicationLogStream.WriteLine(communication);
            Trace.WriteLine(communication);
            _currentlyWritingCommunicationLog = false;
        }
    }
}
