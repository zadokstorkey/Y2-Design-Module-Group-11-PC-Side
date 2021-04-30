using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace OscilloscopePCSide.ViewModel
{
    public interface IDerivedSourceConfigViewModel : INotifyPropertyChanged
    {
        string Name { get; set; }

        Color Color { get; }

        string ColorString { get; set; }

        string Operation { get; set; }

        ISourceConfigViewModel SourceConfigViewModel1 { get; set; }

        ISourceConfigViewModel SourceConfigViewModel2 { get; set; }

        void ApplyChanges();

        void CancelChanges();
    }
}
