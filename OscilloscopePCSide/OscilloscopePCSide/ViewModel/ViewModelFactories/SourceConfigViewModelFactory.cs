using OscilloscopePCSide.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OscilloscopePCSide.ViewModel.ViewModelFactories
{
    public class SourceConfigViewModelFactory : ISourceConfigViewModelFactory
    {
        private ISerialPortListProviderService _serialPortListProviderService;
        private IMultiProbeDataViewModel _multiProbeDataViewModel;

        public SourceConfigViewModelFactory(ISerialPortListProviderService serialPortListProviderService, IMultiProbeDataViewModel multiProbeDataViewModel)
        {
            _serialPortListProviderService = serialPortListProviderService;
            _multiProbeDataViewModel = multiProbeDataViewModel;
        }

        public ISourceConfigViewModel Create(string name, string colourName, string comPort)
        {
            var probeDataParsingService = new ProbeDataParsingService();
            var serialPortConnectionService = new SerialPortConnectionService();
            var probeDataReadingService = new ProbeDataReadingService(probeDataParsingService, serialPortConnectionService, this._multiProbeDataViewModel);
            probeDataReadingService.Start("");
            var sourceConfigViewModel = new SourceConfigViewModel(probeDataReadingService, this._serialPortListProviderService, name, colourName, comPort);
            return sourceConfigViewModel;
        }
    }
}
