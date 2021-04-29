using OscilloscopePCSide.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OscilloscopePCSide.Services
{
    public interface IProbeDataReadingService
    {
        IProbeDataParsingService ProbeDataParsingService { get; }
        ISerialPortConnectionService SerialPortConnectionService { get; }

        IMultiProbeDataViewModel MultiProbeDataViewModel { get; }

        void Start(string comPort);

        void SetCOMPort(string comPort);

        void SetReadTriggeredData(bool readTriggeredData);

        void SetAFGSettings(int freq, int amplitude, string waveformType);

        void SetProbeSetting(bool x10);

        void SetSampleTime(int sampleTime);

        void SetXResolution(int xResolution);

        void SetYResolution(int xResolution);

        void SetTriggerType(bool risingTrigger);

        void SetTriggerLevel(int triggerLevel);

        void SendNextMessage();
    }
}
