using GalaSoft.MvvmLight;
using OscilloscopePCSide.Services;
using OscilloscopePCSide.ViewModel.ViewModelFactories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace OscilloscopePCSide.ViewModel
{
    public class SourcesTabViewModel : ViewModelBase, ISourcesTabViewModel
    {
        private int _sourceCount;

        private readonly IList<string> _colorList;

        private ISourceConfigViewModelFactory _sourceConfigViewModelFactory;

        private ISerialPortListProviderService _serialPortListProviderService;

        public ISourceConfigViewModelFactory SourceConfigViewModelFactory
        {
            get
            {
                return _sourceConfigViewModelFactory;
            }
        }

        public ISerialPortListProviderService SerialPortListProviderService
        {
            get
            {
                return _serialPortListProviderService;
            }
        }

        public ObservableCollection<ISourceConfigViewModel> Sources { get; }

        public SourcesTabViewModel(ISourceConfigViewModelFactory sourceConfigViewModelFactory, ISerialPortListProviderService serialPortListProviderService)
        {
            this._sourceCount = 1;
            this._colorList = new List<string>()
            {
                "Red",
                "Blue",
                "Green",
                "Magenta",
                "Cyan",
                "Yellow"
            };
            this._sourceConfigViewModelFactory = sourceConfigViewModelFactory;
            this._serialPortListProviderService = serialPortListProviderService;
            this.Sources = new ObservableCollection<ISourceConfigViewModel>();
            foreach (SerialPortInfo spi in _serialPortListProviderService.GetSerialPortInfos())
            {
                if (spi.Description == "STMicroelectronics STLink Virtual COM Port")
                {
                    AddNewSource(spi.Name);
                }
            }
        }

        public void AddNewSource(string comPort = "")
        {
            this.Sources.Add(_sourceConfigViewModelFactory.Create("Source " + this._sourceCount, this._colorList[(this._sourceCount-1) % this._colorList.Count], comPort));
            this._sourceCount++;
        }
    }
}
