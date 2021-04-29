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
        private bool _readTriggeredData;

        private bool _successfullyReceivingData;

        private Timer _timer;

        private Queue<string> _priorityMessageQueue;

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

        public ProbeDataReadingService(IProbeDataParsingService probeDataParsingService, ISerialPortConnectionService serialPortConnectionService, IMultiProbeDataViewModel multiProbeDataViewModel)
        {
            this._probeDataParsingService = probeDataParsingService;
            this._serialPortConnectionService = serialPortConnectionService;
            this._multiProbeDataViewModel = multiProbeDataViewModel;
            this._priorityMessageQueue = new Queue<string>();
            this._readTriggeredData = false;
        }

        public void Start()
        {
            this._serialPortConnectionService.Connect();

            //this.SetAFGSettings(800, 3300, "sine");

            this._serialPortConnectionService.MessageReceived += OnSerialPortMessageReceived;

            this._timer = new Timer(this.OnTimerTick, null, 0, 20000);
        }

        public void SetReadTriggeredData(bool readTriggeredData)
        {
            this._readTriggeredData = readTriggeredData;
        }

        public void SetAFGSettings(int freq, int amplitude, string waveformType)
        {
            this._priorityMessageQueue.Enqueue("S" + "afg_freq" + " " + freq.ToString() + " ");
            this._priorityMessageQueue.Enqueue("S" + "afg_amplitude" + " " + amplitude.ToString() + " ");
            this._priorityMessageQueue.Enqueue("S" + "afg_waveform" + " " + waveformType.ToString() + " ");
        }

        public void SendNextMessage()
        {
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

                // Next two lines are temporary until we start differentiating between the two
                this._multiProbeDataViewModel.Probe1ProbeDataViewModel.ProbeData.Frames.Add(probeDataFrame);
                this._multiProbeDataViewModel.Probe2ProbeDataViewModel.ProbeData.Frames.Add(probeDataFrame);
            }

            this.SendNextMessage();
        }
    }
}
