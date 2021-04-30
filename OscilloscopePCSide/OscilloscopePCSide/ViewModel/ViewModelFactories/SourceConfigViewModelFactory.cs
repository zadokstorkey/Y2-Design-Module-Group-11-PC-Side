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
        private ILoggingService _loggingService;

        public SourceConfigViewModelFactory(ISerialPortListProviderService serialPortListProviderService, ILoggingService loggingService)
        {
            _serialPortListProviderService = serialPortListProviderService;
            _loggingService = loggingService;
        }

        public ISourceConfigViewModel Create(string name, string colourName, string comPort)
        {
            var probeDataParsingService = new ProbeDataParsingService();
            var serialPortConnectionService = new SerialPortConnectionService(this._loggingService);
            var probeDataReadingService = new ProbeDataReadingService(probeDataParsingService, serialPortConnectionService);
            probeDataReadingService.Start("");
            var sourceConfigViewModel = new SourceConfigViewModel(probeDataReadingService, this._serialPortListProviderService, name, colourName, comPort);
            return sourceConfigViewModel;
        }
    }
}
