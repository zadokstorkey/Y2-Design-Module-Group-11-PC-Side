using System;
using System.Collections.Generic;
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

        string Title { get; set; }

        double Scale { get; set; }

        double VoltageScale { get; set; }

        string VoltageScaleString { get; set; }

        bool Probe1Visible { get; set; }

        bool Probe2Visible { get; set; }

        string Probe1VisibilityString { get; }

        string Probe2VisibilityString { get; }

        string Probe1Color { get; }

        string Probe2Color { get; }

        void HandleProbe1Clicked();

        void HandleProbe2Clicked();
    }
}
