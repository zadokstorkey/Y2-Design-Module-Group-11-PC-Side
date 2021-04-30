using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OscilloscopePCSide.ViewModel
{
    public interface IDerivedProbeDataViewModel : IProbeDataViewModelBase
    {

        IDerivedSourceConfigViewModel DerivedSourceConfig { get; }

        string TracePath { get; }

        string TracePathAverageOf10 { get; }

        string TracePathAverageOf50 { get; }
    }
}
