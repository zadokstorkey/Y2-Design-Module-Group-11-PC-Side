using GalaSoft.MvvmLight;
using OscilloscopePCSide.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OscilloscopePCSide.Model
{
    public class MainWindowViewModel : ViewModelBase, IMainWIndowViewModel
    {
        private ISourcesTabViewModel _sourcesTabViewModel;

        private IMainDockingViewViewModel _mainDockingViewViewModel;

        public ISourcesTabViewModel SourcesTabViewModel
        {
            get
            {
                return _sourcesTabViewModel;
            }
            set
            {
                _sourcesTabViewModel = value;
                RaisePropertyChanged(nameof(MainWindowViewModel));
            }
        }

        public IMainDockingViewViewModel MainDockingViewViewModel
        {
            get
            {
                return _mainDockingViewViewModel;
            }
            set
            {
                _mainDockingViewViewModel = value;
                RaisePropertyChanged(nameof(MainDockingViewViewModel));
            }
        }

        public MainWindowViewModel(ISourcesTabViewModel sourcesTabViewModel, IMainDockingViewViewModel mainDockingViewViewModel)
        {
            _sourcesTabViewModel = sourcesTabViewModel;
            _mainDockingViewViewModel = mainDockingViewViewModel;
        }
    }
}
