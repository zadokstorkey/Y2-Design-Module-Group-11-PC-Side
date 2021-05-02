using System;
using System.Collections.Concurrent;
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
        private ConcurrentQueue<string> _rawCommunicationLogWriteQueue;
        private ConcurrentQueue<string> _communicationLogWriteQueue;

        private StreamWriter _rawCommunicationLogStream;
        private StreamWriter _communicationLogStream;

        public LoggingService()
        {
            _rawCommunicationLogWriteQueue = new ConcurrentQueue<string>();
            _communicationLogWriteQueue = new ConcurrentQueue<string>();
            _rawCommunicationLogStream = new StreamWriter("rawcommunication.log", false);
            _communicationLogStream = new StreamWriter("communication.log", false);

            LogRawCommunicationLoop();
            LogCommunicationLoop();
        }

        public void LogRawCommunication(string rawCommunication)
        {
            _rawCommunicationLogWriteQueue.Enqueue(rawCommunication);
        }

        public void LogCommunication(string communication)
        {
            _communicationLogWriteQueue.Enqueue(communication);
        }

        private void LogRawCommunicationLoop()
        {
            new Task(() =>
            {
                while (true)
                {
                    if (_rawCommunicationLogWriteQueue.Count > 0)
                    {
                        string currentRawCommunication;
                        if (_rawCommunicationLogWriteQueue.TryDequeue(out currentRawCommunication))
                        {
                            _rawCommunicationLogStream.Write(currentRawCommunication);
                        }
                    }
                    Thread.Yield();
                }
            }).Start();
        }

        private void LogCommunicationLoop()
        {
            new Task(() =>
            {
                while (true)
                {
                    if (_communicationLogWriteQueue.Count > 0)
                    {
                        string currentCommunication;
                        if (_communicationLogWriteQueue.TryDequeue(out currentCommunication))
                        {
                            _communicationLogStream.WriteLine(currentCommunication);
                            Trace.WriteLine(currentCommunication);
                        }
                    }
                }
                Thread.Yield();
            }).Start();
        }
    }
}
