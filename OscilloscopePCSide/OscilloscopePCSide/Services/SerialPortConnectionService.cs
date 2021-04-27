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
        private SerialPort _serialPort;

        private string _currentSerialPortMessage;

        private StreamWriter _rawCommunicationLogger;
        private StreamWriter _communicationLogger;

        public event EventHandler<MessageReceivedEventArgs> MessageReceived;

        public SerialPortConnectionService()
        {
            _serialPort = new SerialPort();
            _communicationLogger = new StreamWriter("communication.log", false);
            _rawCommunicationLogger = new StreamWriter("rawcommunication.log", false);
        }

        public void Connect()
        {
            var stm32DeviceID = "";

            ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("Select * From Win32_SerialPort");
            ManagementObjectCollection managementObjectCollection = managementObjectSearcher.Get();
            foreach (ManagementObject managementObject in managementObjectCollection)
            {
                if (managementObject["Description"].ToString() == "STMicroelectronics STLink Virtual COM Port")
                {
                    stm32DeviceID = managementObject["DeviceID"] as string;
                }
            }

            if (stm32DeviceID == "")
            {
                MessageBox.Show("The device was not found. Please make sure the device is plugged in before staring the application. The application currently looks for the serial port with the description 'STMicroelectronics STLink Virtual COM Port'.", "Device not found.", MessageBoxButton.OK, MessageBoxImage.Error);
                throw new ApplicationException("Oscilloscope is not connected to computer, please connect the oscilloscope and try again.");
            }

            Trace.WriteLine(stm32DeviceID);

            _serialPort.PortName = stm32DeviceID;
            _serialPort.BaudRate = 115200;
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

        public void SendMessage(string message)
        {
            try
            {
                _serialPort.Write(message);
                _rawCommunicationLogger.Write(message);
                _communicationLogger.WriteLine("Sent: " + message);
                Trace.WriteLine("Sent: " + message);
            }
            catch (Exception e)
            {
                MessageBox.Show("Error when trying to send a message to the device over a serial port. This may be because the device has disconnected or it could be for another reason.", "Error sending message to device", MessageBoxButton.OK, MessageBoxImage.Error);
                throw new ApplicationException("Error when trying to send a message to the device over a serial port.", e);
            }
        }

        private void OnDataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            var additionalMessagepart = _serialPort.ReadExisting();
            _rawCommunicationLogger.Write(additionalMessagepart);
            this._currentSerialPortMessage = this._currentSerialPortMessage + additionalMessagepart;

            if (this._currentSerialPortMessage.Contains('>'))
            {
                var completeMessage = this._currentSerialPortMessage.Split('>')[0];
                _communicationLogger.WriteLine("Received: " + completeMessage);
                Trace.WriteLine("Received: " + completeMessage);
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
            MessageBox.Show("Serial port was closed unexpectedly.", "Serial port was closed unexpectedly", MessageBoxButton.OK, MessageBoxImage.Error);
            throw new ApplicationException("Serial port was closed unexpectedly.");
        }
    }
}
