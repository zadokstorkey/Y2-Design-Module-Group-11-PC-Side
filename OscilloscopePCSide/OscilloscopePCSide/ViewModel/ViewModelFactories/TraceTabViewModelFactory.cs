using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OscilloscopePCSide.ViewModel.ViewModelFactories
{
    public class TraceTabViewModelFactory : ITraceTabViewModelFactory
    {
        public ITraceTabViewModel Create()
        {
            var traceTabViewModel = new TraceTabViewModel();
            return traceTabViewModel;
        }
    }
}
