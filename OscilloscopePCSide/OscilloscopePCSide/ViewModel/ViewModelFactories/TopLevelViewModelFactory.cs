using OscilloscopePCSide.Model;
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
            var sourcesTabViewModel = new SourcesTabViewModel();

            // Replace below with scopedata created from services, or just pass the services them selves to the scopedataviewmodels
            var probe1ScopeData = new ScopeData();
            var probe2ScopeData = new ScopeData();
            var probe1ScopeDataViewModel = new ScopeDataViewModel(probe1ScopeData);
            var probe2ScopeDataViewModel = new ScopeDataViewModel(probe2ScopeData);
            var multiScopeDataViewModel = new MultiScopeDataViewModel(probe1ScopeDataViewModel, probe2ScopeDataViewModel);
            var topLevelViewModel = new TopLevelViewModel(traceTabViewModelFactory, sourcesTabViewModel, multiScopeDataViewModel);
            return topLevelViewModel;
        }
    }
}
