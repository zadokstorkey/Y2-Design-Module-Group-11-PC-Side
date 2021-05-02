using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace OscilloscopePCSide.Services
{
    public class SerialPortConnectionService : ISerialPortConnectionService
    {
        private ILoggingService _loggingService;

        private SerialPort _serialPort;

        private string _currentSerialPortMessage;

        public ILoggingService LoggingService
        {
            get
            {
                return _loggingService;
            }
        }

        public event EventHandler<MessageReceivedEventArgs> MessageReceived;

        public SerialPortConnectionService(ILoggingService loggingService)
        {
            _serialPort = new SerialPort();
            _loggingService = loggingService;
        }

        public void Connect(string deviceID)
        {

            _serialPort.PortName = deviceID;
            _serialPort.BaudRate = 1843200;
            _serialPort.DataBits = 8;
            _serialPort.StopBits = StopBits.One;
            _serialPort.Parity = Parity.None;
            _serialPort.Encoding = Encoding.UTF8;
            _serialPort.Handshake = Handshake.XOnXOff;
            _serialPort.DataReceived += OnDataReceived;
            _serialPort.ErrorReceived += OnErrorOccured;
            _serialPort.Disposed += OnDisposed;
            _serialPort.NewLine = "\r\n";

            try
            {
                _serialPort.Open();
            }
            catch (Exception e)
            {
                MessageBox.Show("Error when trying to open serial port with device. This means that the device was detected but the serial port didn't open successfully. This may be because something else, like a terminal, is already connected to the device's serial port.", "Error opening serial port with device", MessageBoxButton.OK, MessageBoxImage.Error);
                throw new ApplicationException("Error opening serial port with device.", e);
            }
        }

        public void Disconnect()
        {
            _serialPort.Close();
        }

        public void SendMessage(string message)
        {
            try
            {
                // send characters one at a time so that it isn't to fast for the board to handle
                foreach (char c in message)
                {
                    _serialPort.Write(c.ToString());
                }
                _loggingService.LogRawCommunication(message);
                _loggingService.LogCommunication("Sent: " + message);
            }
            catch (Exception e)
            {
                MessageBox.Show("Error when trying to send a message to the device over a serial port. This may be because the device has disconnected or it could be because the device is the wrong type of device.", "Error sending message to device", MessageBoxButton.OK, MessageBoxImage.Error);
                throw new ApplicationException("Error when trying to send a message to the device over a serial port.", e);
            }
        }

        private void OnDataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            var additionalMessagepart = _serialPort.ReadExisting();
            _loggingService.LogRawCommunication(additionalMessagepart);
            this._currentSerialPortMessage = this._currentSerialPortMessage + additionalMessagepart;

            if (this._currentSerialPortMessage.Contains('>'))
            {
                var completeMessage = this._currentSerialPortMessage.Split('>')[0];
                _loggingService.LogCommunication("Received: " + completeMessage);
                this._currentSerialPortMessage = this._currentSerialPortMessage.Substring(completeMessage.Length+1);
                MessageReceived.Invoke(this, new MessageReceivedEventArgs(completeMessage));
            }
        }

        private void OnErrorOccured(object sender, SerialErrorReceivedEventArgs e)
        {
            _serialPort.Close();
            MessageBox.Show("An unknown error occured.", "An unknown error occured", MessageBoxButton.OK, MessageBoxImage.Error);
            throw new ApplicationException("An unknown error occured.");
        }

        private void OnDisposed(object sender, EventArgs e)
        {
            // no-op
        }
    }
}
