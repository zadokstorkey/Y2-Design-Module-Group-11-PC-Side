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

        void Start();
    }
}
