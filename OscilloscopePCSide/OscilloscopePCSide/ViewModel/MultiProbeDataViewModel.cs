using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OscilloscopePCSide.ViewModel
{
    public class MultiProbeDataViewModel : ViewModelBase, IMultiProbeDataViewModel
    {
        private readonly ISourcesTabViewModel _sourcesTabViewModel;

        private readonly ObservableCollection<IProbeDataViewModel> _probeDataViewModels;

        public ISourcesTabViewModel SourcesTabViewModel
        {
            get
            {
                return _sourcesTabViewModel;
            }
        }

        public ObservableCollection<IProbeDataViewModel> ProbeDataViewModels
        {
            get
            {
                return _probeDataViewModels;
            }
        }

        public MultiProbeDataViewModel(ISourcesTabViewModel sourcesTabViewModel)
        {
            this._sourcesTabViewModel = sourcesTabViewModel;
            this._probeDataViewModels = new ObservableCollection<IProbeDataViewModel>();

            foreach (ISourceConfigViewModel source in this._sourcesTabViewModel.Sources)
            {
                // replace with factory
                this._probeDataViewModels.Add(new ProbeDataViewModel(source.ProbeDataReadingService.ProbeData, source));
            }

            this._sourcesTabViewModel.Sources.CollectionChanged += Sources_CollectionChanged;
        }

        private void Sources_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                this._probeDataViewModels.Add(new ProbeDataViewModel(((ISourceConfigViewModel)e.NewItems[0]).ProbeDataReadingService.ProbeData, (ISourceConfigViewModel)e.NewItems[0]));
            }
            else if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                this._probeDataViewModels.Remove(this._probeDataViewModels.First(pdvm => pdvm.Source == e.OldItems[0]));
            }
            else
            {
                throw new NotImplementedException("CollectionChanged event handler not implemented for this change type as it should never occur.");
            }
        }
    }
}
