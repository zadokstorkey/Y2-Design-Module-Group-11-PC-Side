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
        private IProbeDataViewModel _probeDataViewModel;

        private bool _visible;

        public IProbeDataViewModel ProbeDataViewModel
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
                return _probeDataViewModel.Source.Name;
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
                return _visible ? ProbeDataViewModel.Source.ColorString : "Gray";
            }
        }

        public TraceSourceViewModel(IProbeDataViewModel probeDataViewModel)
        {
            this._probeDataViewModel = probeDataViewModel;
            ProbeDataViewModel.Source.PropertyChanged += Source_PropertyChanged;
        }

        public void HandleToggleVisibility()
        {
            this.Visible = !this.Visible;
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
