﻿using GalaSoft.MvvmLight;
using OscilloscopePCSide.Services;
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
        private readonly IProbeDataReadingService _probeDataReadingService;

        private string _newName;

        private Color _newColor;

        private string _newColorString;

        private string _newProbeType;

        private string _newTriggerStatus;

        private string _newAFGStatus;

        private int _newAFGFrequency;

        private int _newAFGAmplitude;

        private string _newAFGWaveform;

        private string _name;

        private Color _color;

        private string _colorString;

        private string _probeType;

        private string _triggerStatus;

        private string _afgStatus;

        private int _afgFrequency;

        private int _afgAmplitude;

        private string _afgWaveform;

        public IProbeDataReadingService ProbeDataReadingService
        {
            get
            {
                return _probeDataReadingService;
            }
        }

        public string NewName
        {
            get
            {
                return _newName;
            }
            set
            {
                _newName = value;
                RaisePropertyChanged(nameof(NewName));
            }
        }

        public Color NewColor
        {
            get
            {
                return _newColor;
            }
        }

        public string NewColorString
        {
            get
            {
                return _newColorString;
            }
            set
            {
                _newColorString = value;
                RaisePropertyChanged(nameof(NewColorString));
                _newColor = (Color)ColorConverter.ConvertFromString(_newColorString);
                RaisePropertyChanged(nameof(NewColor));
            }
        }

        public string NewProbeType
        {
            get
            {
                return _newProbeType;
            }
            set
            {
                _newProbeType = value;
                RaisePropertyChanged(nameof(NewProbeType));
            }
        }

        public string NewTriggerStatus
        {
            get
            {
                return _newTriggerStatus;
            }
            set
            {
                _newTriggerStatus = value;
                RaisePropertyChanged(nameof(NewTriggerStatus));
            }
        }

        public string NewAFGStatus
        {
            get
            {
                return _newAFGStatus;
            }
            set
            {
                _newAFGStatus = value;
                RaisePropertyChanged(nameof(NewAFGStatus));
                RaisePropertyChanged(nameof(NewAFGStatusIsAFGOn));
            }
        }

        public bool NewAFGStatusIsAFGOn
        {
            get
            {
                return _newAFGStatus == "AFG On";
            }
        }

        public int NewAFGFrequency
        {
            get
            {
                return _newAFGFrequency;
            }
            set
            {
                _newAFGFrequency = value;
                RaisePropertyChanged(nameof(NewAFGFrequency));
            }
        }

        public int NewAFGAmplitude
        {
            get
            {
                return _newAFGAmplitude;
            }
            set
            {
                _newAFGAmplitude = value;
                RaisePropertyChanged(nameof(NewAFGAmplitude));
            }
        }

        public string NewAFGWaveform
        {
            get
            {
                return _newAFGWaveform;
            }
            set
            {
                _newAFGWaveform = value;
                RaisePropertyChanged(nameof(NewAFGWaveform));
            }
        }

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

        public ChannelConfigViewModel(IProbeDataReadingService probeDataReadingService, string name, string colorName)
        {
            _probeDataReadingService = probeDataReadingService;

            _name = name;
            _color = (Color)ColorConverter.ConvertFromString(colorName);
            _colorString = colorName;
            _probeType = "x1";
            _triggerStatus = "Trigger Off";
            _afgStatus = "AFG Off";
            _afgFrequency = 800;
            _afgAmplitude = 3300;
            _afgWaveform = "Sine Wave";

            _newName = _name;
            _newColor = _color;
            _newColorString = _colorString;
            _newProbeType = _probeType;
            _newTriggerStatus = _triggerStatus;
            _newAFGStatus = _afgStatus;
            _newAFGFrequency = _afgFrequency;
            _newAFGAmplitude = _afgAmplitude;
            _newAFGWaveform = _afgWaveform;
        }

        public void ApplyChanges()
        {
            _probeDataReadingService.SetReadTriggeredData(_newTriggerStatus == "Trigger On");
            if (_afgStatus != _newAFGStatus || _afgFrequency != _newAFGFrequency || _afgAmplitude != _newAFGAmplitude || _afgWaveform != _newAFGWaveform)
            {
                _probeDataReadingService.SetAFGSettings(_newAFGStatus == "AFG On" ? _afgFrequency : 0, _afgAmplitude, _afgWaveform.Replace(" Wave", "").ToLower());
            }
            if (_probeType != _newProbeType)
            {
                _probeDataReadingService.SetProbeSetting(_newProbeType == "x10");
            }

            _name = _newName;
            _color = _newColor;
            _colorString = _newColorString;
            _probeType = _newProbeType;
            _triggerStatus = _newTriggerStatus;
            _afgStatus = _newAFGStatus;
            _afgFrequency = _newAFGFrequency;
            _afgAmplitude = _newAFGAmplitude;
            _afgWaveform = _newAFGWaveform;
            RaisePropertyChanged(nameof(Name));
            RaisePropertyChanged(nameof(Color));
            RaisePropertyChanged(nameof(ColorString));
            RaisePropertyChanged(nameof(ProbeType));
            RaisePropertyChanged(nameof(TriggerStatus));
            RaisePropertyChanged(nameof(AFGStatus));
            RaisePropertyChanged(nameof(AFGFrequency));
            RaisePropertyChanged(nameof(AFGAmplitude));
            RaisePropertyChanged(nameof(AFGWaveform));
        }

        public void CancelChanges()
        {
            _newName = _name;
            _newColor = _color;
            _newColorString = _colorString;
            _newProbeType = _probeType;
            _newTriggerStatus = _triggerStatus;
            _newAFGStatus = _afgStatus;
            _newAFGFrequency = _afgFrequency;
            _newAFGAmplitude = _afgAmplitude;
            _newAFGWaveform = _afgWaveform;
            RaisePropertyChanged(nameof(NewName));
            RaisePropertyChanged(nameof(NewColor));
            RaisePropertyChanged(nameof(NewColorString));
            RaisePropertyChanged(nameof(NewProbeType));
            RaisePropertyChanged(nameof(NewTriggerStatus));
            RaisePropertyChanged(nameof(NewAFGStatus));
            RaisePropertyChanged(nameof(NewAFGFrequency));
            RaisePropertyChanged(nameof(NewAFGAmplitude));
            RaisePropertyChanged(nameof(NewAFGWaveform));
        }
    }
}
