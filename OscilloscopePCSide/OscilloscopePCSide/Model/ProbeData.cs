using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OscilloscopePCSide.Model
{
    public class ProbeData : ObservableObject
    {
        private readonly ObservableCollection<ProbeDataFrame> _frames;

        public ObservableCollection<ProbeDataFrame> Frames
        {
            get
            {
                return _frames;
            }
        }

        public ProbeDataFrame MostRecentFrame
        {
            get
            {
                if (_frames.Count > 0)
                {
                    return _frames.Last();
                }
                else
                {
                    // temp - replace with something better later
                    return new ProbeDataFrame(DateTime.Now, new List<int>());
                }
            }
        }

        public ProbeData()
        {
            this._frames = new ObservableCollection<ProbeDataFrame>();
            this._frames.CollectionChanged += OnFramesPropertyChanged;
        }

        public void OnFramesPropertyChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            this.RaisePropertyChanged(nameof(Frames));
            this.RaisePropertyChanged(nameof(MostRecentFrame));
        }
    }
}
