using GalaSoft.MvvmLight;
using OscilloscopePCSide.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OscilloscopePCSide.ViewModel
{
    public interface IProbeDataViewModel : INotifyPropertyChanged
    {
        ProbeData ProbeData { get; }
    }
}
