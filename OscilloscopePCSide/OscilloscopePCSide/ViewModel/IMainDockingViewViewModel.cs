using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OscilloscopePCSide.ViewModel
{
    public interface IMainDockingViewViewModel : INotifyPropertyChanged
    {
        ITraceTabViewModelFactory TraceTabViewModelFactory { get; set; }

        ISourcesTabViewModel SourcesTabViewModel { get; set; }

        ObservableCollection<ITraceTabViewModel> TraceTabViewModels { get; set; }
    }
}
