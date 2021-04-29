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

            var serialPortListProviderService = new SerialPortListProviderService();
            serialPortListProviderService.Start();

            var loggingService = new LoggingService();

            var sourceConfigViewModelFactory = new SourceConfigViewModelFactory(serialPortListProviderService, multiProbeDataViewModel, loggingService);
            var sourceConfigViewModel1 = sourceConfigViewModelFactory.Create("Source 1", "Red", "");
            var sourceConfigViewModel2 = sourceConfigViewModelFactory.Create("Source 2", "Blue", "");
            var sources = new List<ISourceConfigViewModel> { sourceConfigViewModel1, sourceConfigViewModel2 };
            var sourcesTabViewModel = new SourcesTabViewModel(sources);

            var topLevelViewModel = new TopLevelViewModel(traceTabViewModelFactory, sourcesTabViewModel, multiProbeDataViewModel);

            return topLevelViewModel;
        }
    }
}
