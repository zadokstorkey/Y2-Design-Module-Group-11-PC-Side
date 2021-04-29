﻿using GalaSoft.MvvmLight;
using OscilloscopePCSide.Services;
using OscilloscopePCSide.ViewModel.ViewModelFactories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OscilloscopePCSide.ViewModel
{
    public class SourcesTabViewModel : ViewModelBase, ISourcesTabViewModel
    {
        private ISourceConfigViewModelFactory _sourceConfigViewModelFactory;

        private ISerialPortListProviderService _serialPortListProviderService;

        public ISourceConfigViewModelFactory SourceConfigViewModelFactory
        {
            get
            {
                return _sourceConfigViewModelFactory;
            }
        }

        public ISerialPortListProviderService SerialPortListProviderService
        {
            get
            {
                return _serialPortListProviderService;
            }
        }

        public ObservableCollection<ISourceConfigViewModel> Sources { get; }

        public SourcesTabViewModel(ISourceConfigViewModelFactory sourceConfigViewModelFactory, ISerialPortListProviderService serialPortListProviderService)
        {
            this._sourceConfigViewModelFactory = sourceConfigViewModelFactory;
            this._serialPortListProviderService = serialPortListProviderService;
            this.Sources = new ObservableCollection<ISourceConfigViewModel>();
            foreach (SerialPortInfo spi in _serialPortListProviderService.GetSerialPortInfos())
            {
                if (spi.Description == "STMicroelectronics STLink Virtual COM Port")
                {
                    this.Sources.Add(sourceConfigViewModelFactory.Create("Source 1", "Red", spi.Name));
                }
            }
        }
    }
}
