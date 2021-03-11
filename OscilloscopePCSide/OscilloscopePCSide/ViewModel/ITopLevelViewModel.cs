﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OscilloscopePCSide.ViewModel
{
    public interface ITopLevelViewModel : INotifyPropertyChanged
    {
        ITraceTabViewModelFactory TraceTabViewModelFactory { get; }

        ISourcesTabViewModel SourcesTabViewModel { get; }

        ObservableCollection<ITraceTabViewModel> TraceTabViewModels { get; }

        IMultiProbeDataViewModel MultiProbeDataViewModel { get; }
    }
}
