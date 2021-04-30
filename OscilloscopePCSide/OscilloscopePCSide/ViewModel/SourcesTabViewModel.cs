using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Threading;
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

        private IDerivedSourceConfigViewModelFactory _derivedSourceConfigViewModelFactory;

        private ISerialPortListProviderService _serialPortListProviderService;

        public ISourceConfigViewModelFactory SourceConfigViewModelFactory
        {
            get
            {
                return _sourceConfigViewModelFactory;
            }
        }

        public IDerivedSourceConfigViewModelFactory DerivedSourceConfigViewModelFactory
        {
            get
            {
                return _derivedSourceConfigViewModelFactory;
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

        public ObservableCollection<IDerivedSourceConfigViewModel> DerivedSources { get; }

        public SourcesTabViewModel(ISourceConfigViewModelFactory sourceConfigViewModelFactory, IDerivedSourceConfigViewModelFactory derivedSourceConfigViewModelFactory, ISerialPortListProviderService serialPortListProviderService)
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
            this._derivedSourceConfigViewModelFactory = derivedSourceConfigViewModelFactory;
            this._serialPortListProviderService = serialPortListProviderService;
            this.Sources = new ObservableCollection<ISourceConfigViewModel>();
            this.DerivedSources = new ObservableCollection<IDerivedSourceConfigViewModel>();
            new Task(() =>
            {
                foreach (SerialPortInfo spi in _serialPortListProviderService.GetSerialPortInfos())
                {
                    if (spi.Description == "STMicroelectronics STLink Virtual COM Port")
                    {
                        DispatcherHelper.CheckBeginInvokeOnUI(() => AddNewSource(spi.Name));
                    }
                }
            }).Start();
            this._serialPortListProviderService.SerialPortListUpdated += SerialPortListProviderService_SerialPortListUpdated;
        }

        public void AddNewSource(string comPort = "")
        {
            this.Sources.Add(_sourceConfigViewModelFactory.Create("Source " + this._sourceCount, this._colorList[(this._sourceCount-1) % this._colorList.Count], comPort));
            this._sourceCount++;
        }

        public void AddNewDerivedSource()
        {
            this.DerivedSources.Add(_derivedSourceConfigViewModelFactory.Create(this, "Source " + this._sourceCount, this._colorList[(this._sourceCount - 1) % this._colorList.Count]));
            this._sourceCount++;
        }

        private void SerialPortListProviderService_SerialPortListUpdated(object sender, EventArgs e)
        {
            new Task(() =>
            {
                foreach (SerialPortInfo spi in _serialPortListProviderService.GetSerialPortInfos())
                {
                    if (spi.Description == "STMicroelectronics STLink Virtual COM Port" && !this.Sources.Any(s => s.Name == spi.Name))
                    {
                        DispatcherHelper.CheckBeginInvokeOnUI(() => AddNewSource(spi.Name));
                    }
                }
            }).Start();
        }
    }
}
