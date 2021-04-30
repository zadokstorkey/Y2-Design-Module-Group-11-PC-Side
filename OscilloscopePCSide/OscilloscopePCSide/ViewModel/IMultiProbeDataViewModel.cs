using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OscilloscopePCSide.ViewModel
{
    public interface IMultiProbeDataViewModel : INotifyPropertyChanged
    {
        ISourcesTabViewModel SourcesTabViewModel { get; }

        ObservableCollection<IProbeDataViewModel> ProbeDataViewModels { get; }

        ObservableCollection<IDerivedProbeDataViewModel> DerivedProbeDataViewModels { get; }
    }
}
