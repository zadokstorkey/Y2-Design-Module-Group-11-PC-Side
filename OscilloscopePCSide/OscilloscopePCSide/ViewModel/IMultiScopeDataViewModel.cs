using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OscilloscopePCSide.ViewModel
{
    public interface IMultiScopeDataViewModel : INotifyPropertyChanged
    {
        IScopeDataViewModel Probe1ScopeDataViewModel { get; }
        IScopeDataViewModel Probe2ScopeDataViewModel { get; }
    }
}
