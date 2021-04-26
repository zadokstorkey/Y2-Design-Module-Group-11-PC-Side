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

        private double _scale;

        private double _maxVoltage;

        private string _maxVoltageString;

        private bool _probe1Visible;

        private bool _probe2Visible;

        public IMultiProbeDataViewModel MultiProbeDataViewModel
        {
            get
            {
                return this._multiProbeDataViewModel;
            }
        }

        public string Title
        {
            get
            {
                return this._title;
            }
            set
            {
                this._title = value;
                RaisePropertyChanged(nameof(Title));
            }
        }

        public double Scale
        {
            get
            {
                return this._scale;
            }
            set
            {
                this._scale = value;
                RaisePropertyChanged(nameof(Scale));
                this._maxVoltage = 3.3 / value;
                RaisePropertyChanged(nameof(MaxVoltage));
                this._maxVoltageString = this._maxVoltage.ToString("0.#V");
                RaisePropertyChanged(nameof(MaxVoltageString));
            }
        }

        public double MaxVoltage
        {
            get
            {
                return this._maxVoltage;
            }
            set
            {
                this._maxVoltage = value;
                RaisePropertyChanged(nameof(MaxVoltage));
                this._scale = 3.3 / value;
                RaisePropertyChanged(nameof(Scale));
                this._maxVoltageString = value.ToString("0.#V");
                RaisePropertyChanged(nameof(MaxVoltageString));
            }
        }

        public string MaxVoltageString
        {
            get
            {
                return this._maxVoltageString;
            }
            set
            {
                this._maxVoltageString = value;
                RaisePropertyChanged(nameof(MaxVoltageString));
                if (double.TryParse(value.Replace("V", ""), out this._maxVoltage))
                {
                    RaisePropertyChanged(nameof(MaxVoltage));
                    this._scale =  3.3 / this._maxVoltage;
                    RaisePropertyChanged(nameof(Scale));
                }
            }
        }

        public bool Probe1Visible
        {
            get
            {
                return this._probe1Visible;
            }
            set
            {
                this._probe1Visible = value;
                RaisePropertyChanged(nameof(Probe1Visible));
                RaisePropertyChanged(nameof(Probe1VisibilityString));
                RaisePropertyChanged(nameof(Probe1Color));
            }
        }

        public bool Probe2Visible
        {
            get
            {
                return this._probe2Visible;
            }
            set
            {
                this._probe2Visible = value;
                RaisePropertyChanged(nameof(Probe2Visible));
                RaisePropertyChanged(nameof(Probe2VisibilityString));
                RaisePropertyChanged(nameof(Probe2Color));
            }
        }

        public string Probe1VisibilityString
        {
            get
            {
                return this._probe1Visible ? "Visible" : "Hidden";
            }
        }

        public string Probe2VisibilityString
        {
            get
            {
                return this._probe2Visible ? "Visible" : "Hidden";
            }
        }

        public string Probe1Color
        {
            get
            {
                return this._probe1Visible ? "Red" : "Gray";
            }
        }

        public string Probe2Color
        {
            get
            {
                return this._probe2Visible ? "Blue" : "Gray";
            }
        }

        public TraceTabViewModel(IMultiProbeDataViewModel multiProbeDataViewModel)
        {
            this._multiProbeDataViewModel = multiProbeDataViewModel;
            this._title = "Untitled Trace";
            this._scale = 1;
            this._maxVoltage = 3.3;
            this._maxVoltageString = "3.3V";
            this._probe1Visible = true;
            this._probe2Visible = false;
        }

        public void HandleProbe1Clicked()
        {
            this._probe1Visible = !_probe1Visible;
            RaisePropertyChanged(nameof(Probe1Visible));
            RaisePropertyChanged(nameof(Probe1VisibilityString));
            RaisePropertyChanged(nameof(Probe1Color));
        }

        public void HandleProbe2Clicked()
        {
            this._probe2Visible = !_probe2Visible;
            RaisePropertyChanged(nameof(Probe2Visible));
            RaisePropertyChanged(nameof(Probe2VisibilityString));
            RaisePropertyChanged(nameof(Probe2Color));
        }
    }
}
