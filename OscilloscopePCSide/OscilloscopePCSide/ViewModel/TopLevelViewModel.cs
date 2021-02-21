﻿using GalaSoft.MvvmLight;
using OscilloscopePCSide.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OscilloscopePCSide.Model
{
    public class MainWindowViewModel : ViewModelBase, ITopLevelViewModel
    {
        private ITraceTabViewModelFactory _traceTabViewModelFactory;

        private ISourcesTabViewModel _sourcesTabViewModel;

        private ObservableCollection<ITraceTabViewModel> _traceTabViewModels;

        public ITraceTabViewModelFactory TraceTabViewModelFactory
        {
            get
            {
                return _traceTabViewModelFactory;
            }
            set
            {
                _traceTabViewModelFactory = value;
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
                RaisePropertyChanged(nameof(MainWindowViewModel));
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
            }
        }

        public MainWindowViewModel(ITraceTabViewModelFactory traceTabViewModelFactory, ISourcesTabViewModel sourcesTabViewModel)
        {
            _traceTabViewModelFactory = traceTabViewModelFactory;
            _sourcesTabViewModel = sourcesTabViewModel;
        }
    }
}