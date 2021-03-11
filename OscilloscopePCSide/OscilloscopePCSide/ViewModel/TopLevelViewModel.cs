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
        private ITraceTabViewModelFactory _traceTabViewModelFactory;

        private ISourcesTabViewModel _sourcesTabViewModel;

        private ObservableCollection<ITraceTabViewModel> _traceTabViewModels;

        private IMultiProbeDataViewModel _multiProbeDataViewModel;

        public ITraceTabViewModelFactory TraceTabViewModelFactory
        {
            get
            {
                return _traceTabViewModelFactory;
            }
            set
            {
                _traceTabViewModelFactory = value;
                RaisePropertyChanged(nameof(TraceTabViewModelFactory));
            }
        }

        public ISourcesTabViewModel SourcesTabViewModel
        {
            get
            {
                return _sourcesTabViewModel;
            }
            set
            {
                _sourcesTabViewModel = value;
                RaisePropertyChanged(nameof(SourcesTabViewModel));
            }
        }

        public ObservableCollection<ITraceTabViewModel> TraceTabViewModels
        {
            get
            {
                return _traceTabViewModels;
            }
            set
            {
                _traceTabViewModels = value;
                RaisePropertyChanged(nameof(TraceTabViewModels));
            }
        }

        public IMultiProbeDataViewModel MultiProbeDataViewModel
        {
            get
            {
                return _multiProbeDataViewModel;
            }
            set
            {
                _multiProbeDataViewModel = value;
                RaisePropertyChanged(nameof(MultiProbeDataViewModel));
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
