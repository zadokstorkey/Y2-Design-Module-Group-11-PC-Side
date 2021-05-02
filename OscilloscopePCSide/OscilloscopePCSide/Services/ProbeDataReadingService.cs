using OscilloscopePCSide.Model;
using OscilloscopePCSide.ViewModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;

namespace OscilloscopePCSide.Services
{
    public class ProbeDataReadingService : IProbeDataReadingService
    {
        private bool _currentlyConnected;

        private bool _readTriggeredData;

        private bool _successfullyReceivingData;

        private Timer _timer;

        private Queue<string> _priorityMessageQueue;

        private ProbeData _probeData;

        private readonly IProbeDataParsingService _probeDataParsingService;
        
        private readonly ISerialPortConnectionService _serialPortConnectionService;

        private readonly IMultiProbeDataViewModel _multiProbeDataViewModel;

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

        public IMultiProbeDataViewModel MultiProbeDataViewModel
        {
            get
            {
                return this._multiProbeDataViewModel;
            }
        }

        public ProbeData ProbeData
        {
            get
            {
                return _probeData;
            }
        }

        public ProbeDataReadingService(IProbeDataParsingService probeDataParsingService, ISerialPortConnectionService serialPortConnectionService)
        {
            this._probeDataParsingService = probeDataParsingService;
            this._serialPortConnectionService = serialPortConnectionService;
            this._priorityMessageQueue = new Queue<string>();
            this._readTriggeredData = false;
            this._currentlyConnected = false;
            this._probeData = new ProbeData();
        }

        public void Start(string comPort)
        {
            this._serialPortConnectionService.MessageReceived += OnSerialPortMessageReceived;

            this._timer = new Timer(this.OnTimerTick, null, 0, 20000);

            SetCOMPort(comPort);
        }

        public void SetCOMPort(string comPort)
        {
            if (_currentlyConnected)
            {
                this._serialPortConnectionService.Disconnect();
                _currentlyConnected = false;
            }
            if (comPort != "")
            {
                this._serialPortConnectionService.Connect(comPort);
                _currentlyConnected = true;
                _successfullyReceivingData = true;
                SendNextMessage();
            }
        }

        public void SetReadTriggeredData(bool readTriggeredData)
        {
            this._readTriggeredData = readTriggeredData;
        }

        public void SetAFGSettings(int freq, int amplitude, string waveformType)
        {
            SetValue("afg_freq", freq.ToString());
            SetValue("afg_amplitude", amplitude.ToString());
            SetValue("afg_waveform", waveformType.ToString());
        }

        public void SetProbeSetting(bool x10)
        {
            SetValue("amplifier_x10", (x10 ? 1 : 0).ToString());
        }

        public void SetSampleTime(int sampleTime)
        {
            SetValue("sample_time", sampleTime.ToString());
        }

        public void SetXResolution(int xResolution)
        {
            SetValue("resolution_x", xResolution.ToString());
        }

        public void SetYResolution(int yResolution)
        {
            SetValue("resolution_y", yResolution.ToString());
        }

        public void SetTriggerType(bool risingTrigger)
        {
            SetValue("trigger_rising", (risingTrigger ? 1 : 0).ToString());
        }

        public void SetTriggerLevel(int triggerLevel)
        {
            SetValue("trigger_level", triggerLevel.ToString());
        }

        public void SendNextMessage()
        {
            if (!_currentlyConnected)
            {
                return;
            }
            if (_priorityMessageQueue.Count > 0)
            {
                this._serialPortConnectionService.SendMessage(_priorityMessageQueue.Dequeue());
            }
            else
            {
                if (this._readTriggeredData)
                {
                    this._serialPortConnectionService.SendMessage("T");
                }
                else
                {
                    this._serialPortConnectionService.SendMessage("A");
                }
            }
        }

        private void SetValue(string variable, string value)
        {
            this._priorityMessageQueue.Enqueue("S" + variable + " " + value + " ");
        }

        private void OnTimerTick(object state)
        {
            // Only request data if we haven't recieved any data recently
            if (!_successfullyReceivingData)
            {
                SendNextMessage();
            }

            // reset the variable so that we can track if anything is received in the next 5 seconds
            _successfullyReceivingData = false;
        }

        private void OnSerialPortMessageReceived(object sender, MessageReceivedEventArgs e)
        {
            this._successfullyReceivingData = true;

            var message = e.Message;

            if (message.Contains("|"))
            {
                var heights = _probeDataParsingService.ParseProbeData(message);
                var probeDataFrame = new ProbeDataFrame(DateTime.Now, heights);

                var temp = "";
                probeDataFrame.Heights.ForEach(h => temp += h.ToString() + ", ");
                Trace.Write(temp);
                Trace.WriteLine("");

                this.ProbeData.Frames.Add(new ProbeDataFrame(DateTime.Now, heights));
            }

            this.SendNextMessage();
        }
    }
}
