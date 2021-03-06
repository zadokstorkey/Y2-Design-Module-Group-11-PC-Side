﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OscilloscopePCSide.Services
{
    public interface ISerialPortConnectionService
    {
        ILoggingService LoggingService { get; }

        event EventHandler<MessageReceivedEventArgs> MessageReceived;

        void Connect(string deviceID);

        void Disconnect();

        void SendMessage(string message);
    }

    public class MessageReceivedEventArgs : EventArgs
    {
        public readonly string _message;

        public string Message
        {
            get
            {
                return _message;
            }
        }

        public MessageReceivedEventArgs(string message)
        {
            this._message = message;
        }
    }
}
