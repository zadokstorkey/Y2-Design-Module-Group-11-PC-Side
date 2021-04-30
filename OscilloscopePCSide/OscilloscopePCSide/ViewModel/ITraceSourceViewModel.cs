using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OscilloscopePCSide.ViewModel
{
    public interface ITraceSourceViewModel : INotifyPropertyChanged
    {
        IProbeDataViewModelBase ProbeDataViewModel { get; }

        string Name { get; }

        bool Visible { get; set; }

        string VisibilityString { get; }

        string Color { get; }

        string AveragingMode { get; set; }

        void HandleToggleVisibility();
    }
}
