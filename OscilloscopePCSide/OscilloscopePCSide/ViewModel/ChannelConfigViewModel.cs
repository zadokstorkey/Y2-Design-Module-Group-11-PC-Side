using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace OscilloscopePCSide.ViewModel
{
    public class ChannelConfigViewModel : ViewModelBase, IChannelConfigViewModel
    {
        private string _name;

        private Color _color;

        private string _colorString;

        private string _probeType;

        private string _triggerStatus;

        private string _afgStatus;

        private int _afgFrequency;

        private int _afgAmplitude;

        private string _afgWaveform;

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                RaisePropertyChanged(nameof(Name));
            }
        }

        public Color Color
        {
            get
            {
                return _color;
            }
        }

        public string ColorString
        {
            get
            {
                return _colorString;
            }
            set
            {
                _colorString = value;
                RaisePropertyChanged(nameof(ColorString));
                _color = (Color)ColorConverter.ConvertFromString(_colorString);
                RaisePropertyChanged(nameof(Color));
            }
        }

        public string ProbeType
        {
            get
            {
                return _probeType;
            }
            set
            {
                _probeType = value;
                RaisePropertyChanged(nameof(ProbeType));
            }
        }

        public string TriggerStatus
        {
            get
            {
                return _triggerStatus;
            }
            set
            {
                _triggerStatus = value;
                RaisePropertyChanged(nameof(TriggerStatus));
            }
        }

        public string AFGStatus
        {
            get
            {
                return _afgStatus;
            }
            set
            {
                _afgStatus = value;
                RaisePropertyChanged(nameof(AFGStatus));
            }
        }

        public int AFGFrequency
        {
            get
            {
                return _afgFrequency;
            }
            set
            {
                _afgFrequency = value;
                RaisePropertyChanged(nameof(AFGFrequency));
            }
        }

        public int AFGAmplitude
        {
            get
            {
                return _afgAmplitude;
            }
            set
            {
                _afgAmplitude = value;
                RaisePropertyChanged(nameof(AFGAmplitude));
            }
        }

        public string AFGWaveform
        {
            get
            {
                return _afgWaveform;
            }
            set
            {
                _afgWaveform = value;
                RaisePropertyChanged(nameof(AFGWaveform));
            }
        }

        public ChannelConfigViewModel(string name, string colorName)
        {
            _name = name;
            _color = (Color)ColorConverter.ConvertFromString(colorName);
            _colorString = colorName;
            _probeType = "x1";
            _triggerStatus = "Trigger Off";
            _afgStatus = "AFG Off";
            _afgFrequency = 800;
            _afgAmplitude = 3300;
            _afgWaveform = "Sine Wave";
    }

        public void ApplyChanges()
        {

        }
    }
}
