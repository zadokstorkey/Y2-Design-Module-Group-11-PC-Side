using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OscilloscopePCSide.ViewModel
{
    public class TraceTabViewModel : ViewModelBase, ITraceTabViewModel
    {
        private readonly IMultiProbeDataViewModel _multiProbeDataViewModel;

        private string _title;

        private bool _probe1Visible;

        private bool _probe2Visible;


        public IMultiProbeDataViewModel MultiProbeDataViewModel
        {
            get
            {
                return _multiProbeDataViewModel;
            }
        }

        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                _title = value;
                RaisePropertyChanged(nameof(Title));
            }
        }

        public bool Probe1Visible
        {
            get
            {
                return _probe1Visible;
            }
            set
            {
                _probe1Visible = value;
                RaisePropertyChanged(nameof(Probe1Visible));
                RaisePropertyChanged(nameof(Probe1VisibilityString));
                RaisePropertyChanged(nameof(Probe1Color));
            }
        }

        public bool Probe2Visible
        {
            get
            {
                return _probe2Visible;
            }
            set
            {
                _probe2Visible = value;
                RaisePropertyChanged(nameof(Probe2Visible));
                RaisePropertyChanged(nameof(Probe2VisibilityString));
                RaisePropertyChanged(nameof(Probe2Color));
            }
        }

        public string Probe1VisibilityString
        {
            get
            {
                return Probe1Visible ? "Visible" : "Hidden";
            }
        }

        public string Probe2VisibilityString
        {
            get
            {
                return Probe2Visible ? "Visible" : "Hidden";
            }
        }

        public string Probe1Color
        {
            get
            {
                return Probe1Visible ? "Red" : "Gray";
            }
        }

        public string Probe2Color
        {
            get
            {
                return Probe2Visible ? "Blue" : "Gray";
            }
        }

        public TraceTabViewModel(IMultiProbeDataViewModel multiProbeDataViewModel)
        {
            this._multiProbeDataViewModel = multiProbeDataViewModel;
            _title = "Untitled Trace";
            _probe1Visible = true;
            _probe2Visible = false;
        }

        public void HandleProbe1Clicked()
        {
            _probe1Visible = !_probe1Visible;
            RaisePropertyChanged(nameof(Probe1Visible));
            RaisePropertyChanged(nameof(Probe1VisibilityString));
            RaisePropertyChanged(nameof(Probe1Color));
        }

        public void HandleProbe2Clicked()
        {
            _probe2Visible = !_probe2Visible;
            RaisePropertyChanged(nameof(Probe2Visible));
            RaisePropertyChanged(nameof(Probe2VisibilityString));
            RaisePropertyChanged(nameof(Probe2Color));
        }
    }
}
