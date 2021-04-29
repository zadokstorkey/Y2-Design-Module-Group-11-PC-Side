using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace OscilloscopePCSide.ViewModel
{
    public interface ITraceTabViewModel : INotifyPropertyChanged
    {
        IMultiProbeDataViewModel MultiProbeDataViewModel { get; }

        ObservableCollection<ITraceSourceViewModel> TraceSourceViewModels { get; }

        string Title { get; set; }

        double TraceHeight { get; set; }

        double Scale { get; set; }

        double VoltageScale { get; set; }

        string VoltageScaleString { get; set; }

        double ScaledOffset { get; }

        double Offset { get; set; }

        double VoltageOffset { get; set; }

        string VoltageOffsetString { get; set; }
    }
}
