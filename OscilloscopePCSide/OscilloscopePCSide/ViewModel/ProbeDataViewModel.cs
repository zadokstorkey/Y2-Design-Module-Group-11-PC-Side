using GalaSoft.MvvmLight;
using OscilloscopePCSide.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OscilloscopePCSide.ViewModel
{
    public class ProbeDataViewModel : ViewModelBase, IProbeDataViewModel
    {
        private readonly ISourceConfigViewModelBase _sourceConfig;
        private readonly ProbeData _probeData;

        public ISourceConfigViewModelBase SourceConfig
        {
            get
            {
                return _sourceConfig;
            }
        }

        public ProbeData ProbeData
        {
            get
            {
                return this._probeData;
            }
        }

        public string TracePath
        {
            get
            {
                var tracePath = "M 0 8192 M 0 -8192 ";
                for (var i = 0; i < this._probeData.MostRecentFrame.Heights.Count; i++)
                {
                    tracePath += i == 0 ? "M " : "L ";
                    tracePath += i.ToString() + " ";
                    tracePath += (-this._probeData.MostRecentFrame.Heights[i]).ToString() + " ";
                }
                return tracePath;
            }
        }

        public string TracePathAverageOf10
        {
            get
            {
                var tracePath = "M 0 8192 M 0 -8192 ";
                for (var i = 0; i < this._probeData.MostRecentFrame.Heights.Count; i++)
                {
                    tracePath += i == 0 ? "M " : "L ";
                    tracePath += i.ToString() + " ";
                    var averageHeight = 0;
                    for (var j = 0; j < 10; j++)
                    {
                        if (j < this._probeData.Frames.Count)
                        {
                            averageHeight += this._probeData.Frames[this._probeData.Frames.Count - 1 - j].Heights[i];
                        }
                    }
                    averageHeight /= 10;
                    tracePath += (-averageHeight).ToString() + " ";
                }
                return tracePath;
            }
        }

        public string TracePathAverageOf50
        {
            get
            {
                var tracePath = "M 0 8192 M 0 -8192 ";
                for (var i = 0; i < this._probeData.MostRecentFrame.Heights.Count; i++)
                {
                    tracePath += i == 0 ? "M " : "L ";
                    tracePath += i.ToString() + " ";
                    var averageHeight = 0;
                    for (var j = 0; j < 50; j++)
                    {
                        if (j < this._probeData.Frames.Count)
                        {
                            averageHeight += this._probeData.Frames[this._probeData.Frames.Count - 1 - j].Heights[i];
                        }
                    }
                    averageHeight /= 50;
                    tracePath += (-averageHeight).ToString() + " ";
                }
                return tracePath;
            }
        }

        public ProbeDataViewModel(ISourceConfigViewModelBase sourceConfig, ProbeData probeData)
        {
            this._sourceConfig = sourceConfig;
            this._probeData = probeData;
            probeData.PropertyChanged += OnProbeDataChanged;
        }

        public void OnProbeDataChanged(object sender, PropertyChangedEventArgs e)
        {
            RaisePropertyChanged(nameof(ProbeData));
            RaisePropertyChanged(nameof(TracePath));
            RaisePropertyChanged(nameof(TracePathAverageOf10));
            RaisePropertyChanged(nameof(TracePathAverageOf50));
        }
    }
}
