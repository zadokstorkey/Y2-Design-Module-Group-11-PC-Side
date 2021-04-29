using OscilloscopePCSide.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace OscilloscopePCSide.ViewModel
{
    public interface IChannelConfigViewModel : INotifyPropertyChanged
    {
        IProbeDataReadingService ProbeDataReadingService { get; }

        string NewName { get; set; }

        Color NewColor { get; }

        string NewColorString { get; set; }

        string NewProbeType { get; set; }

        string NewTriggerStatus { get; set; }

        string NewAFGStatus { get; set; }

        bool NewAFGStatusIsAFGOn { get; }

        int NewAFGFrequency { get; set; }

        int NewAFGAmplitude { get; set; }

        string NewAFGWaveform { get; set; }

        string Name { get; set; }

        Color Color { get; }

        string ColorString { get; set; }

        string ProbeType { get; set; }

        string TriggerStatus { get; set; }

        string AFGStatus { get; set; }

        int AFGFrequency { get; set; }

        int AFGAmplitude { get; set; }

        string AFGWaveform { get; set; }

        void ApplyChanges();
    }
}
