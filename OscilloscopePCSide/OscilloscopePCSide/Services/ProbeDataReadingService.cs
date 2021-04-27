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
        private Timer _timer;

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
        }

        public async void Start()
        {
            this._serialPortConnectionService.Connect();

            this._serialPortConnectionService.SendMessage("S");
            this._serialPortConnectionService.SendMessage("afg_freq");
            this._serialPortConnectionService.SendMessage("\n");
            this._serialPortConnectionService.SendMessage("0.5");
            this._serialPortConnectionService.SendMessage("\n");

            //await this._serialPortConnectionService.WaitUntilMessageReceived();

            this._serialPortConnectionService.SendMessage("S");
            this._serialPortConnectionService.SendMessage("afg_amplitude");
            this._serialPortConnectionService.SendMessage("\n");
            this._serialPortConnectionService.SendMessage("3300");
            this._serialPortConnectionService.SendMessage("\n");

            //await this._serialPortConnectionService.WaitUntilMessageReceived();

            this._serialPortConnectionService.SendMessage("S");
            this._serialPortConnectionService.SendMessage("afg_waveform");
            this._serialPortConnectionService.SendMessage("\n");
            this._serialPortConnectionService.SendMessage("square");
            this._serialPortConnectionService.SendMessage("\n");

            //await this._serialPortConnectionService.WaitUntilMessageReceived();

            this._serialPortConnectionService.MessageReceived += OnSerialPortMessageReceived;

            this._timer = new Timer(this.OnTimerTick, null, 0, 1000);
        }

        private void OnTimerTick(object state)
        {
            this.SendDataRequest();
        }

        public void SendDataRequest()
        {
            this._serialPortConnectionService.SendMessage("A");
        }

        public void OnSerialPortMessageReceived(object sender, MessageReceivedEventArgs e)
        {
            var message = e.Message;
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
    }
}
