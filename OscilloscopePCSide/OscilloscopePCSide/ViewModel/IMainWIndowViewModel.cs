using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OscilloscopePCSide.ViewModel
{
    public interface IMainWIndowViewModel : INotifyPropertyChanged
    {
        ISourcesTabViewModel SourcesTabViewModel { get; set; }

        IMainDockingViewViewModel MainDockingViewViewModel { get; set; }
    }
}
