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

        private readonly ObservableCollection<IDerivedProbeDataViewModel> _derivedProbeDataViewModels;

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

        public ObservableCollection<IDerivedProbeDataViewModel> DerivedProbeDataViewModels
        {
            get
            {
                return _derivedProbeDataViewModels;
            }
        }

        public MultiProbeDataViewModel(ISourcesTabViewModel sourcesTabViewModel)
        {
            this._sourcesTabViewModel = sourcesTabViewModel;
            this._probeDataViewModels = new ObservableCollection<IProbeDataViewModel>();
            this._derivedProbeDataViewModels = new ObservableCollection<IDerivedProbeDataViewModel>();

            foreach (ISourceConfigViewModel sourceConfig in this._sourcesTabViewModel.Sources)
            {
                // replace with factory
                this._probeDataViewModels.Add(new ProbeDataViewModel(sourceConfig, sourceConfig.ProbeDataReadingService.ProbeData));
            }

            this._sourcesTabViewModel.Sources.CollectionChanged += Sources_CollectionChanged;
            this._sourcesTabViewModel.DerivedSources.CollectionChanged += DerivedSources_CollectionChanged;
        }

        private void Sources_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                // replace with factory
                this._probeDataViewModels.Add(new ProbeDataViewModel((ISourceConfigViewModel)e.NewItems[0], ((ISourceConfigViewModel)e.NewItems[0]).ProbeDataReadingService.ProbeData));
            }
            else if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                this._probeDataViewModels.Remove(this._probeDataViewModels.First(pdvm => pdvm.ProbeData == ((ISourceConfigViewModel)e.OldItems[0]).ProbeDataReadingService.ProbeData));
            }
            else
            {
                throw new NotImplementedException("CollectionChanged event handler not implemented for this change type as it should never occur.");
            }
        }

        private void DerivedSources_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                // replace with factory
                this._derivedProbeDataViewModels.Add(new DerivedProbeDataViewModel((IDerivedSourceConfigViewModel)e.NewItems[0]));
            }
            else if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                this._derivedProbeDataViewModels.Remove(this._derivedProbeDataViewModels.First(dpdvm => dpdvm.SourceConfig == (IDerivedSourceConfigViewModel)e.OldItems[0]));
            }
            else
            {
                throw new NotImplementedException("CollectionChanged event handler not implemented for this change type as it should never occur.");
            }
        }
    }
}
