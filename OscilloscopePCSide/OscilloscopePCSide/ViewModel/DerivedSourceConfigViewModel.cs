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

        private string _newOperation;

        private ISourceConfigViewModel _newSourceConfigViewModel1;

        private ISourceConfigViewModel _newSourceConfigViewModel2;

        private string _name;

        private Color _color;

        private string _colorString;

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
                _color = (Color)ColorConverter.ConvertFromString(value); ;
                RaisePropertyChanged(nameof(Color));
                _colorString = value;
                RaisePropertyChanged(nameof(ColorString));
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
            this._name = name;
            this._colorString = colorName;
        }
    }
}
