using GalaSoft.MvvmLight;
using OscilloscopePCSide.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OscilloscopePCSide.ViewModel
{
    public class TopLevelViewModel : ViewModelBase, ITopLevelViewModel
    {
        private readonly ITraceTabViewModelFactory _traceTabViewModelFactory;

        private readonly ISourcesTabViewModel _sourcesTabViewModel;

        private readonly ObservableCollection<ITraceTabViewModel> _traceTabViewModels;

        private readonly IMultiProbeDataViewModel _multiProbeDataViewModel;

        public ITraceTabViewModelFactory TraceTabViewModelFactory
        {
            get
            {
                return _traceTabViewModelFactory;
            }
        }

        public ISourcesTabViewModel SourcesTabViewModel
        {
            get
            {
                return _sourcesTabViewModel;
            }
        }

        public ObservableCollection<ITraceTabViewModel> TraceTabViewModels
        {
            get
            {
                return _traceTabViewModels;
            }
        }

        public IMultiProbeDataViewModel MultiProbeDataViewModel
        {
            get
            {
                return _multiProbeDataViewModel;
            }
        }

        public TopLevelViewModel(ITraceTabViewModelFactory traceTabViewModelFactory, ISourcesTabViewModel sourcesTabViewModel, IMultiProbeDataViewModel multiProbeDataViewModel)
        {
            this._traceTabViewModelFactory = traceTabViewModelFactory;
            this._sourcesTabViewModel = sourcesTabViewModel;

            // This is temporary
            this._traceTabViewModels = new ObservableCollection<ITraceTabViewModel>
            {
                this.TraceTabViewModelFactory.Create(multiProbeDataViewModel),
                this.TraceTabViewModelFactory.Create(multiProbeDataViewModel),
                this.TraceTabViewModelFactory.Create(multiProbeDataViewModel),
                this.TraceTabViewModelFactory.Create(multiProbeDataViewModel)
            };

            this._multiProbeDataViewModel = multiProbeDataViewModel;
        }
    }
}
