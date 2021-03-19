using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Ports;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OscilloscopePCSide.Services
{
    public class SerialPortConnectionService : ISerialPortConnectionService
    {
        private SerialPort _serialPort;

        private string _currentSerialPortMessage;

        public event EventHandler<MessageReceivedEventArgs> MessageReceived;

        public SerialPortConnectionService()
        {
            _serialPort = new SerialPort();
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

            try
            {
                _serialPort.Open();
            }
            catch (Exception e)
            {
                throw new ApplicationException("Error when trying to open serial port with device.", e);
            }
        }

        public void SendMessage(string message)
        {
            _serialPort.Write(message);
            Trace.WriteLine("Sent: " + message);
        }

        private void OnDataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            this._currentSerialPortMessage = this._currentSerialPortMessage + _serialPort.ReadExisting();
            if (this._currentSerialPortMessage.Contains('>'))
            {
                var completeMessage = this._currentSerialPortMessage.Split('>')[0];
                Trace.Write("Received: " + completeMessage);
                Trace.WriteLine("");
                this._currentSerialPortMessage = this._currentSerialPortMessage.Substring(completeMessage.Length+1);
                MessageReceived.Invoke(this, new MessageReceivedEventArgs(completeMessage));
            }
        }

        private void OnErrorOccured(object sender, SerialErrorReceivedEventArgs e)
        {
            _serialPort.Close();
            throw new ApplicationException("An unknown error occured.");
        }

        private void OnDisposed(object sender, EventArgs e)
        {
            throw new ApplicationException("Serial port was closed unexpectedly.");
        }
    }
}
