using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OscilloscopePCSide.ViewModel
{
    public interface IProbeDataViewModelBase : INotifyPropertyChanged
    {
        ISourceConfigViewModelBase SourceConfig { get; }

        string TracePath { get; }

        string TracePathAverageOf10 { get; }

        string TracePathAverageOf50 { get; }
    }
}
