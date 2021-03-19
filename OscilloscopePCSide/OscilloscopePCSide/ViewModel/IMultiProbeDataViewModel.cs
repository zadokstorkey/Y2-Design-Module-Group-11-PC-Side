using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OscilloscopePCSide.ViewModel
{
    public interface IMultiProbeDataViewModel : INotifyPropertyChanged
    {
        IProbeDataViewModel Probe1ProbeDataViewModel { get; }
        IProbeDataViewModel Probe2ProbeDataViewModel { get; }
    }
}
