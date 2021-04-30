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

            var serialPortListProviderService = new SerialPortListProviderService();

            serialPortListProviderService.Start();

            var loggingService = new LoggingService();

            var sourceConfigViewModelFactory = new SourceConfigViewModelFactory(serialPortListProviderService, loggingService);
            var derivedSourceConfigViewModelFactory = new DerivedSourceConfigViewModelFactory();
            var sourcesTabViewModel = new SourcesTabViewModel(sourceConfigViewModelFactory, derivedSourceConfigViewModelFactory, serialPortListProviderService);

            var multiProbeDataViewModel = new MultiProbeDataViewModel(sourcesTabViewModel);

            var topLevelViewModel = new TopLevelViewModel(traceTabViewModelFactory, sourcesTabViewModel, multiProbeDataViewModel);

            return topLevelViewModel;
        }
    }
}
