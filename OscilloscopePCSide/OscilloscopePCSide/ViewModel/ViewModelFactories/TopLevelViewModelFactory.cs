using OscilloscopePCSide.Model;
using OscilloscopePCSide.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OscilloscopePCSide.ViewModel.ViewModelFactories
{
    public class TopLevelViewModelFactory : ITopLevelViewModelFactory
    {
        public ITopLevelViewModel Create()
        {
            var traceTabViewModelFactory = new TraceTabViewModelFactory();

            // Replace below with scopedata created from services, or just pass the services them selves to the scopedataviewmodels
            var probe1ProbeData = new ProbeData();
            var probe2ProbeData = new ProbeData();
            var probe1ProbeDataViewModel = new ProbeDataViewModel(probe1ProbeData);
            var probe2ProbeDataViewModel = new ProbeDataViewModel(probe2ProbeData);
            var multiProbeDataViewModel = new MultiProbeDataViewModel(probe1ProbeDataViewModel, probe2ProbeDataViewModel);

            var probeDataParsingService = new ProbeDataParsingService();
            var serialPortConnectionService = new SerialPortConnectionService();
            var probeDataReadingService = new ProbeDataReadingService(probeDataParsingService, serialPortConnectionService, multiProbeDataViewModel);
            probeDataReadingService.Start("");

            var sourceConfigViewModel1 = new ChannelConfigViewModel(probeDataReadingService, "Source 1", "Red", "");
            var sourceConfigViewModel2 = new ChannelConfigViewModel(probeDataReadingService, "Source 2", "Blue", "");
            var sources = new List<ChannelConfigViewModel> { sourceConfigViewModel1, sourceConfigViewModel2 };
            var sourcesTabViewModel = new SourcesTabViewModel(sources);

            var topLevelViewModel = new TopLevelViewModel(traceTabViewModelFactory, sourcesTabViewModel, multiProbeDataViewModel);

            return topLevelViewModel;
        }
    }
}
