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
        private ISourceConfigViewModel _source;

        private readonly ProbeData _probeData;

        public ISourceConfigViewModel Source
        {
            get
            {
                return this._source;
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
                var tracePath = "M 0 4096 M 0 -4096 ";
                for (var i = 0; i < this._probeData.MostRecentFrame.Heights.Count; i++)
                {
                    tracePath += i == 0 ? "M " : "L ";
                    tracePath += i.ToString() + " ";
                    tracePath += (-this._probeData.MostRecentFrame.Heights[i]).ToString() + " ";
                }
                return tracePath;
            }
        }

        public ProbeDataViewModel(ProbeData probeData, ISourceConfigViewModel source)
        {
            this._source = source;
            this._probeData = probeData;
            probeData.PropertyChanged += OnProbeDataChanged;
        }

        public void OnProbeDataChanged(object sender, PropertyChangedEventArgs e)
        {
            RaisePropertyChanged(nameof(ProbeData));
            RaisePropertyChanged(nameof(TracePath));
        }
    }
}
