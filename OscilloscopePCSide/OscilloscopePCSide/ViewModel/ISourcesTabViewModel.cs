using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OscilloscopePCSide.ViewModel
{
    public interface ISourcesTabViewModel : INotifyPropertyChanged
    {
        ObservableCollection<ISourceConfigViewModel> Sources { get; }

        void AddNewSource(string comPort = "");

        void AddNewDerivedSource();
    }
}
