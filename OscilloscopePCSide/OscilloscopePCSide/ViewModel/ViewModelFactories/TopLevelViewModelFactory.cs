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
            var topLevelViewModel = new TopLevelViewModel(traceTabViewModelFactory, sourcesTabViewModel);
            return topLevelViewModel;
        }
    }
}
