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
            _serialPort.BaudRate = 1115200;
            _serialPort.DataBits = 8;
            _serialPort.StopBits = StopBits.One;
            _serialPort.Parity = Parity.None;
            _serialPort.Encoding = Encoding.UTF8;
            _serialPort.DataReceived += OnDataReceived;
            _serialPort.ErrorReceived += OnErrorOccured;
            _serialPort.Disposed += OnDisposed;

            try
            {
                _serialPort.Open();
                while (true)
                {
                    //_serialPort.Write(new Byte[] { 97 }, 0, 1);
                    //Trace.WriteLine("Sent: " + "A");

                    //Thread.Sleep(4000);
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Error when trying to open serial port with device.", e);
            }
        }

        public void OnDataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            var temp = _serialPort.ReadExisting();
            
            Trace.Write("Received: " + temp);
            Trace.WriteLine("");

            if (temp.Replace("\0", "").Length == 0)
            {
                return;
            }

            _serialPort.Close();
            throw new ApplicationException("Test exception: Response");
        }

        public void OnErrorOccured(object sender, SerialErrorReceivedEventArgs e)
        {
            _serialPort.Close();
            throw new ApplicationException("Test exception: Error");
        }

        public void OnDisposed(object sender, EventArgs e)
        {
            _serialPort.Close();
            throw new ApplicationException("Test exception: Disposed");
        }
    }
}
