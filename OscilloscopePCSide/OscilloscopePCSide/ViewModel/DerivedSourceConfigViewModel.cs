using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace OscilloscopePCSide.ViewModel
{
    public class DerivedSourceConfigViewModel : ViewModelBase, IDerivedSourceConfigViewModel
    {
        private ISourcesTabViewModel _sourcesTabViewModel;

        private string _newName;

        private Color _newColor;

        private string _newColorString;

        private int _newXResolution;

        private string _newOperation;

        private ISourceConfigViewModel _newSourceConfigViewModel1;

        private ISourceConfigViewModel _newSourceConfigViewModel2;

        private string _name;

        private Color _color;

        private string _colorString;

        private int _xResolution;

        private string _operation;

        private ISourceConfigViewModel _sourceConfigViewModel1;

        private ISourceConfigViewModel _sourceConfigViewModel2;

        public ISourcesTabViewModel SourcesTabViewModel
        {
            get
            {
                return _sourcesTabViewModel;
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
                _newColor = (Color)ColorConverter.ConvertFromString(value); ;
                RaisePropertyChanged(nameof(NewColor));
                _newColorString = value;
                RaisePropertyChanged(nameof(NewColorString));
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
                RaisePropertyChanged(nameof(NewXResolution));
            }
        }

        public string NewOperation
        {
            get
            {
                return _newOperation;
            }
            set
            {
                _newOperation = value;
                RaisePropertyChanged(nameof(NewOperation));
                RaisePropertyChanged(nameof(NewOperationRequiresTwoSources));
            }
        }

        public bool NewOperationRequiresTwoSources
        {
            get
            {
                return _newOperation == "Add" || _newOperation == "Subtract" || _newOperation == "Average";
            }
        }

        public ISourceConfigViewModel NewSourceConfigViewModel1
        {
            get
            {
                return _newSourceConfigViewModel1;
            }
            set
            {
                _newSourceConfigViewModel1 = value;
                RaisePropertyChanged(nameof(NewSourceConfigViewModel1));
            }
        }

        public ISourceConfigViewModel NewSourceConfigViewModel2
        {
            get
            {
                return _newSourceConfigViewModel2;
            }
            set
            {
                _newSourceConfigViewModel2 = value;
                RaisePropertyChanged(nameof(NewSourceConfigViewModel2));
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
                _color = (Color)ColorConverter.ConvertFromString(value);
                RaisePropertyChanged(nameof(Color));
                _colorString = value;
                RaisePropertyChanged(nameof(ColorString));
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

        public string Operation
        {
            get
            {
                return _operation;
            }
            set
            {
                _operation = value;
                RaisePropertyChanged(nameof(Operation));
            }
        }

        public ISourceConfigViewModel SourceConfigViewModel1
        {
            get
            {
                return _sourceConfigViewModel1;
            }
            set
            {
                _sourceConfigViewModel1 = value;
                RaisePropertyChanged(nameof(SourceConfigViewModel1));
            }
        }

        public ISourceConfigViewModel SourceConfigViewModel2
        {
            get
            {
                return _sourceConfigViewModel2;
            }
            set
            {
                _sourceConfigViewModel2 = value;
                RaisePropertyChanged(nameof(SourceConfigViewModel2));
            }
        }

        public DerivedSourceConfigViewModel(ISourcesTabViewModel sourcesTabViewModel, string name, string colorName)
        {
            this._sourcesTabViewModel = sourcesTabViewModel;

            this._name = name;
            this._color = (Color)ColorConverter.ConvertFromString(colorName);
            this._colorString = colorName;
            this._xResolution = 1920;
            this._operation = "Invert";
            this._sourceConfigViewModel1 = null;
            this._sourceConfigViewModel2 = null;

            this._newName = this._name;
            this._newColor = this._color;
            this._newColorString = this._colorString;
            this._newXResolution = this._xResolution;
            this._newOperation = this._operation;
            this._newSourceConfigViewModel1 = this._sourceConfigViewModel1;
            this._newSourceConfigViewModel2 = this._sourceConfigViewModel2;
        }

        public void ApplyChanges()
        {
            _name = _newName;
            _color = _newColor;
            _colorString = _newColorString;
            _xResolution = _newXResolution;
            _operation = _newOperation;
            _sourceConfigViewModel1 = _newSourceConfigViewModel1;
            _sourceConfigViewModel2 = _newSourceConfigViewModel2;
            RaisePropertyChanged(nameof(Name));
            RaisePropertyChanged(nameof(Color));
            RaisePropertyChanged(nameof(ColorString));
            RaisePropertyChanged(nameof(XResolution));
            RaisePropertyChanged(nameof(Operation));
            RaisePropertyChanged(nameof(SourceConfigViewModel1));
            RaisePropertyChanged(nameof(SourceConfigViewModel2));
        }

        public void CancelChanges()
        {
            _newName = _name;
            _newColor = _color;
            _newColorString = _colorString;
            _newXResolution = _xResolution;
            _newOperation = _operation;
            _newSourceConfigViewModel1 = _sourceConfigViewModel1;
            _newSourceConfigViewModel2 = _sourceConfigViewModel2;
            RaisePropertyChanged(nameof(NewName));
            RaisePropertyChanged(nameof(NewColor));
            RaisePropertyChanged(nameof(NewColorString));
            RaisePropertyChanged(nameof(NewXResolution));
            RaisePropertyChanged(nameof(NewOperation));
            RaisePropertyChanged(nameof(NewSourceConfigViewModel1));
            RaisePropertyChanged(nameof(NewSourceConfigViewModel2));
        }
    }
}
