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
    public class TraceTabViewModel : ViewModelBase, ITraceTabViewModel
    {
        private readonly IMultiProbeDataViewModel _multiProbeDataViewModel;

        private readonly ObservableCollection<ITraceSourceViewModel> _traceSourceViewModels;

        private string _title;

        private double _traceHeight;

        private double _scale;

        private double _voltageScale;

        private string _voltageScaleString;

        private double _offset;

        private double _voltageOffset;

        private string _voltageOffsetString;

        public IMultiProbeDataViewModel MultiProbeDataViewModel
        {
            get
            {
                return this._multiProbeDataViewModel;
            }
        }

        public ObservableCollection<ITraceSourceViewModel> TraceSourceViewModels
        {
            get
            {
                return _traceSourceViewModels;
            }
        }

        public string Title
        {
            get
            {
                return this._title;
            }
            set
            {
                this._title = value;
                RaisePropertyChanged(nameof(Title));
            }
        }

        public double TraceHeight
        { 
            get
            {
                return _traceHeight;
            }
            set
            {
                _traceHeight = value;
                RaisePropertyChanged(nameof(TraceHeight));
                RaisePropertyChanged(nameof(ScaledOffset));
            }
        }


        public double Scale
        {
            get
            {
                return this._scale;
            }
            set
            {
                this._scale = value;
                RaisePropertyChanged(nameof(Scale));
                this._voltageScale = 3.3 / value;
                RaisePropertyChanged(nameof(VoltageScale));
                this._voltageScaleString = this._voltageScale.ToString("0.#V");
                RaisePropertyChanged(nameof(VoltageScaleString));

                RaisePropertyChanged(nameof(ScaledOffset));
            }
        }

        public double VoltageScale
        {
            get
            {
                return this._voltageScale;
            }
            set
            {
                this._voltageScale = value;
                RaisePropertyChanged(nameof(VoltageScale));
                this._scale = 3.3 / value;
                RaisePropertyChanged(nameof(Scale));
                this._voltageScaleString = value.ToString("0.#V");
                RaisePropertyChanged(nameof(VoltageScaleString));

                RaisePropertyChanged(nameof(ScaledOffset));
            }
        }

        public string VoltageScaleString
        {
            get
            {
                return this._voltageScaleString;
            }
            set
            {
                this._voltageScaleString = value;
                RaisePropertyChanged(nameof(VoltageScaleString));
                if (double.TryParse(value.Replace("V", ""), out this._voltageScale))
                {
                    RaisePropertyChanged(nameof(VoltageScale));
                    this._scale =  3.3 / this._voltageScale;
                    RaisePropertyChanged(nameof(Scale));

                    RaisePropertyChanged(nameof(ScaledOffset));
                }
            }
        }

        public double Offset
        {
            get
            {
                return this._offset;
            }
            set
            {
                this._offset = value;
                RaisePropertyChanged(nameof(Offset));
                this._voltageOffset = value * 6.6;
                RaisePropertyChanged(nameof(VoltageOffset));
                this._voltageOffsetString = _voltageOffset.ToString("0.#V");
                RaisePropertyChanged(nameof(VoltageOffsetString));

                RaisePropertyChanged(nameof(ScaledOffset));
            }
        }

        public double VoltageOffset
        { 
            get
            {
                return this._voltageOffset;
            }
            set
            {
                this._voltageOffset = value;
                RaisePropertyChanged(nameof(VoltageOffset));
                this._offset = value / 6.6;
                RaisePropertyChanged(nameof(Offset));
                this._voltageOffsetString = value.ToString("0.#V");
                RaisePropertyChanged(nameof(VoltageOffsetString));

                RaisePropertyChanged(nameof(ScaledOffset));
            }
        }

        public string VoltageOffsetString
        {
            get
            {
                return this._voltageOffsetString;
            }
            set
            {
                this._voltageOffsetString = value;
                RaisePropertyChanged(nameof(VoltageOffsetString));
                if (double.TryParse(value.Replace("V", ""), out this._voltageOffset))
                {
                    RaisePropertyChanged(nameof(VoltageOffset));
                    this._offset = this._voltageOffset / 6.6;
                    RaisePropertyChanged(nameof(Offset));

                    RaisePropertyChanged(nameof(ScaledOffset));
                }
            }
        }

        public double ScaledOffset
        {
            get
            {
                return -(this._offset * this._scale * this._traceHeight);
            }
        }

        public string AveragingMode
        {
            set
            {
                foreach (var tsvm in this._traceSourceViewModels)
                {
                    tsvm.AveragingMode = value;
                }
            }
        }

        public TraceTabViewModel(IMultiProbeDataViewModel multiProbeDataViewModel)
        {
            this._multiProbeDataViewModel = multiProbeDataViewModel;
            this._title = "Untitled Trace";
            this._scale = 1;
            this._voltageScale = 3.3;
            this._voltageScaleString = "3.3V";
            this._offset = 0;
            this._voltageOffset = 0;
            this._voltageOffsetString = "0V";

            this._traceSourceViewModels = new ObservableCollection<ITraceSourceViewModel>();

            foreach (IProbeDataViewModel pdvm in this._multiProbeDataViewModel.ProbeDataViewModels)
            {
                this._traceSourceViewModels.Add(new TraceSourceViewModel(pdvm));
            }
            foreach (IDerivedProbeDataViewModel pdvm in this._multiProbeDataViewModel.DerivedProbeDataViewModels)
            {
                this._traceSourceViewModels.Add(new TraceSourceViewModel(pdvm));
            }

            this._multiProbeDataViewModel.ProbeDataViewModels.CollectionChanged += ProbeDataViewModels_CollectionChanged;
            this._multiProbeDataViewModel.DerivedProbeDataViewModels.CollectionChanged += DerivedProbeDataViewModels_CollectionChanged;
        }

        private void ProbeDataViewModels_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                this._traceSourceViewModels.Add(new TraceSourceViewModel((IProbeDataViewModel)e.NewItems[0]));
            }
            else if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                this._traceSourceViewModels.Remove(this._traceSourceViewModels.First(tsvm => tsvm.ProbeDataViewModel == e.OldItems[0]));
            }
            else
            {
                throw new NotImplementedException("CollectionChanged event handler not implemented for this change type as it should never occur.");
            }
        }

        private void DerivedProbeDataViewModels_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                this._traceSourceViewModels.Add(new TraceSourceViewModel((IDerivedProbeDataViewModel)e.NewItems[0]));
            }
            else if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                this._traceSourceViewModels.Remove(this._traceSourceViewModels.First(tsvm => tsvm.ProbeDataViewModel == e.OldItems[0]));
            }
            else
            {
                throw new NotImplementedException("CollectionChanged event handler not implemented for this change type as it should never occur.");
            }
        }
    }
}
