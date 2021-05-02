using GalaSoft.MvvmLight;
using OscilloscopePCSide.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace OscilloscopePCSide.ViewModel
{
    public class SourceConfigViewModel : ViewModelBase, ISourceConfigViewModel
    {
        private readonly IProbeDataReadingService _probeDataReadingService;

        private readonly ISerialPortListProviderService _serialPortListProviderService;

        private IList<string> _comPortOptions;

        private string _newName;

        private Color _newColor;

        private string _newColorString;

        private string _newCOMPort;

        private int _newSampleTime;

        private int _newXResolution;

        private int _newYResolution;

        private string _newProbeType;

        private string _newTriggerStatus;

        private string _newTriggerType;

        private int _newTriggerLevel;

        private string _newAFGStatus;

        private int _newAFGFrequency;

        private int _newAFGAmplitude;

        private string _newAFGWaveform;

        private string _name;

        private Color _color;

        private string _colorString;

        private string _comPort;

        private int _sampleTime;

        private int _xResolution;

        private int _yResolution;

        private string _probeType;

        private string _triggerStatus;

        private string _triggerType;

        private int _triggerLevel;

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

        public ISerialPortListProviderService SerialPortListProviderService
        {
            get
            {
                return _serialPortListProviderService;
            }
        }

        public IList<string> COMPortOptions
        {
            get
            {
                return _comPortOptions;
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

        public string NewCOMPort
        {
            get
            {
                return _newCOMPort;
            }
            set
            {
                _newCOMPort = value;
                RaisePropertyChanged(nameof(NewCOMPort));
            }
        }

        public int NewSampleTime
        {
            get
            {
                return _newSampleTime;
            }
            set
            {
                _newSampleTime = value;
                RaisePropertyChanged(nameof(NewSampleTime));
            }
        }

        public int NewXResolution
        {
            get
            {
                return _newXResolution;
            }
            set
            {
                _newXResolution = value;
                RaisePropertyChanged(nameof(NewSampleTime));
            }
        }

        public int NewYResolution
        {
            get
            {
                return _newYResolution;
            }
            set
            {
                _newYResolution = value;
                RaisePropertyChanged(nameof(NewSampleTime));
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
                RaisePropertyChanged(nameof(NewTriggerStatusIsTriggerOn));
            }
        }

        public bool NewTriggerStatusIsTriggerOn
        {
            get
            {
                return _newTriggerStatus == "Trigger On";
            }
        }

        public string NewTriggerType
        {
            get
            {
                return _newTriggerType;
            }
            set
            {
                _newTriggerType = value;
                RaisePropertyChanged(nameof(NewTriggerType));
            }
        }

        public int NewTriggerLevel
        {
            get
            {
                return _newTriggerLevel;
            }
            set
            {
                _newTriggerLevel = value;
                RaisePropertyChanged(nameof(NewTriggerLevel));
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

        public string COMPort
        {
            get
            {
                return _comPort;
            }
            set
            {
                _comPort = value;
                RaisePropertyChanged(nameof(COMPort));
            }
        }

        public int SampleTime
        {
            get
            {
                return _sampleTime;
            }
            set
            {
                _sampleTime = value;
                RaisePropertyChanged(nameof(SampleTime));
            }
        }

        public int XResolution
        {
            get
            {
                return _xResolution;
            }
            set
            {
                _xResolution = value;
                RaisePropertyChanged(nameof(XResolution));
            }
        }

        public int YResolution
        {
            get
            {
                return _yResolution;
            }
            set
            {
                _yResolution = value;
                RaisePropertyChanged(nameof(YResolution));
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

        public string TriggerType
        {
            get
            {
                return _triggerType;
            }
            set
            {
                _triggerType = value;
                RaisePropertyChanged(nameof(TriggerType));
            }
        }

        public int TriggerLevel
        {
            get
            {
                return _triggerLevel;
            }
            set
            {
                _triggerLevel = value;
                RaisePropertyChanged(nameof(TriggerLevel));
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

        public SourceConfigViewModel(IProbeDataReadingService probeDataReadingService, ISerialPortListProviderService serialPortListProviderService, string name, string colorName, string comPort)
        {
            _probeDataReadingService = probeDataReadingService;
            _serialPortListProviderService = serialPortListProviderService;
            _serialPortListProviderService.SerialPortListUpdated += SerialPortListProviderService_SerialPortListUpdated;
            _comPortOptions = serialPortListProviderService.GetSerialPortInfos().Select(spi => spi.NameAndDescription).ToList();

            _newName = name;
            _newColor = (Color)ColorConverter.ConvertFromString(colorName);
            _newColorString = colorName;
            _newCOMPort = comPort != "" ? serialPortListProviderService.GetSerialPortInfos().First(spi => spi.Name == comPort).NameAndDescription : "";
            _newSampleTime = 2;
            _newXResolution = 1920;
            _newYResolution = 1080;
            _newProbeType = "x1";
            _newTriggerStatus = "Trigger Off";
            _newTriggerType = "Rising Edge";
            _newTriggerLevel = 2048;
            _newAFGStatus = "AFG Off";
            _newAFGFrequency = 800;
            _newAFGAmplitude = 3300;
            _newAFGWaveform = "Sine Wave";

            ApplyChanges();
        }

        public void ApplyChanges()
        {
            try
            {
                if (_comPort != _newCOMPort)
                {
                    if (_newCOMPort != "")
                    {
                        _probeDataReadingService.SetCOMPort(_serialPortListProviderService.GetSerialPortInfos().First(spi => spi.NameAndDescription == _newCOMPort).Name);
                    }
                    else
                    {
                        _probeDataReadingService.SetCOMPort("");
                    }
                }
                if (_triggerStatus != _newTriggerStatus)
                {
                    _probeDataReadingService.SetReadTriggeredData(_newTriggerStatus == "Trigger On");
                }
                if (_afgStatus != _newAFGStatus || _afgFrequency != _newAFGFrequency || _afgAmplitude != _newAFGAmplitude || _afgWaveform != _newAFGWaveform)
                {
                    _probeDataReadingService.SetAFGSettings(_newAFGStatus == "AFG On" ? _newAFGFrequency : 0, _newAFGAmplitude, _newAFGWaveform.Replace(" Wave", "").ToLower());
                }
                if (_probeType != _newProbeType)
                {
                    _probeDataReadingService.SetProbeSetting(_newProbeType == "x10");
                }
                if (_sampleTime != _newSampleTime)
                {
                    _probeDataReadingService.SetSampleTime(_newSampleTime);
                }
                if (_xResolution != _newXResolution)
                {
                    _probeDataReadingService.SetXResolution(_newXResolution);
                }
                if (_yResolution != _newYResolution)
                {
                    _probeDataReadingService.SetYResolution(_newYResolution);
                }
                if (_triggerType != _newTriggerType)
                {
                    _probeDataReadingService.SetTriggerType(_newTriggerType == "Rising Edge");
                }
                if (_triggerLevel != _newTriggerLevel)
                {
                    _probeDataReadingService.SetTriggerLevel((int)Math.Round(_newTriggerLevel * 4096 / 3.3));
                }
            }
            catch (ApplicationException ex)
            {

            }

            _name = _newName;
            _color = _newColor;
            _colorString = _newColorString;
            _comPort = _newCOMPort;
            _sampleTime = _newSampleTime;
            _xResolution = _newXResolution;
            _yResolution = _newYResolution;
            _probeType = _newProbeType;
            _triggerStatus = _newTriggerStatus;
            _triggerType = _newTriggerType;
            _triggerLevel = _newTriggerLevel;
            _afgStatus = _newAFGStatus;
            _afgFrequency = _newAFGFrequency;
            _afgAmplitude = _newAFGAmplitude;
            _afgWaveform = _newAFGWaveform;
            RaisePropertyChanged(nameof(Name));
            RaisePropertyChanged(nameof(Color));
            RaisePropertyChanged(nameof(ColorString));
            RaisePropertyChanged(nameof(COMPort));
            RaisePropertyChanged(nameof(SampleTime));
            RaisePropertyChanged(nameof(XResolution));
            RaisePropertyChanged(nameof(YResolution));
            RaisePropertyChanged(nameof(ProbeType));
            RaisePropertyChanged(nameof(TriggerStatus));
            RaisePropertyChanged(nameof(TriggerType));
            RaisePropertyChanged(nameof(TriggerLevel));
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
            _newCOMPort = _comPort;
            _newSampleTime = _sampleTime;
            _newXResolution = _xResolution;
            _newYResolution = _yResolution;
            _newProbeType = _probeType;
            _newTriggerStatus = _triggerStatus;
            _newTriggerType = _triggerType;
            _newTriggerLevel = _triggerLevel;
            _newAFGStatus = _afgStatus;
            _newAFGFrequency = _afgFrequency;
            _newAFGAmplitude = _afgAmplitude;
            _newAFGWaveform = _afgWaveform;
            RaisePropertyChanged(nameof(NewName));
            RaisePropertyChanged(nameof(NewColor));
            RaisePropertyChanged(nameof(NewColorString));
            RaisePropertyChanged(nameof(NewCOMPort));
            RaisePropertyChanged(nameof(NewSampleTime));
            RaisePropertyChanged(nameof(NewXResolution));
            RaisePropertyChanged(nameof(NewYResolution));
            RaisePropertyChanged(nameof(NewProbeType));
            RaisePropertyChanged(nameof(NewTriggerStatus));
            RaisePropertyChanged(nameof(NewTriggerType));
            RaisePropertyChanged(nameof(NewTriggerLevel));
            RaisePropertyChanged(nameof(NewAFGStatus));
            RaisePropertyChanged(nameof(NewAFGFrequency));
            RaisePropertyChanged(nameof(NewAFGAmplitude));
            RaisePropertyChanged(nameof(NewAFGWaveform));
        }

        private void SerialPortListProviderService_SerialPortListUpdated(object sender, EventArgs e)
        {
            _comPortOptions = _serialPortListProviderService.GetSerialPortInfos().Select(spi => spi.NameAndDescription).ToList();
            RaisePropertyChanged(nameof(COMPortOptions));
        }
    }
}
