using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OscilloscopePCSide.ViewModel
{
    public class TraceSourceViewModel : ViewModelBase, ITraceSourceViewModel
    {
        private IProbeDataViewModelBase _probeDataViewModel;

        private bool _visible;

        private string _averagingMode;

        public IProbeDataViewModelBase ProbeDataViewModel
        {
            get
            {
                return _probeDataViewModel;
            }
        }

        public string Name
        {
            get
            {
                return _probeDataViewModel.SourceConfig.Name;
            }
        }

        public bool Visible
        {
            get
            {
                return _visible;
            }
            set
            {
                _visible = value;
                RaisePropertyChanged(nameof(Visible));
                RaisePropertyChanged(nameof(VisibilityString));
                RaisePropertyChanged(nameof(Color));
            }
        }

        public string VisibilityString
        {
            get
            {
                return _visible ? "Visible" : "Hidden";
            }
        }

        public string Color
        {
            get
            {
                return _visible ? ProbeDataViewModel.SourceConfig.ColorString : "Gray";
            }
        }

        public string AveragingMode
        {
            get
            {
                return _averagingMode;
            }
            set
            {
                _averagingMode = value;
                RaisePropertyChanged(nameof(AveragingMode));
                RaisePropertyChanged(nameof(TracePath));
            }
        }

        public string TracePath
        {
            get
            {
                if (_averagingMode == "Average 10")
                {
                    return ProbeDataViewModel.TracePathAverageOf10;
                }
                else if (_averagingMode == "Average 50")
                {
                    return ProbeDataViewModel.TracePathAverageOf50;
                }
                else
                {
                    return ProbeDataViewModel.TracePath;
                }
            }
        }

        public TraceSourceViewModel(IProbeDataViewModelBase probeDataViewModel)
        {
            this._probeDataViewModel = probeDataViewModel;
            ProbeDataViewModel.PropertyChanged += ProbeDataViewModel_PropertyChanged;
            ProbeDataViewModel.SourceConfig.PropertyChanged += Source_PropertyChanged;
        }

        public void HandleToggleVisibility()
        {
            this.Visible = !this.Visible;
        }

        private void ProbeDataViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(ProbeDataViewModel.TracePath))
            {
                RaisePropertyChanged(nameof(TracePath));
            }
        }

        private void Source_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(SourceConfigViewModel.ColorString))
            {
                RaisePropertyChanged(nameof(Color));
            }
            else if (e.PropertyName == nameof(SourceConfigViewModel.Name))
            {
                RaisePropertyChanged(nameof(Name));
            }
        }
    }
}
