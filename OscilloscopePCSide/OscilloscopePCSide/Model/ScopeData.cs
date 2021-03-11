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
    public class ScopeData : ObservableObject
    {
        private readonly ObservableCollection<ScopeDataFrame> _frames;

        public ObservableCollection<ScopeDataFrame> Frames
        {
            get
            {
                return _frames;
            }
        }

        public ScopeDataFrame MostRecentFrame
        {
            get
            {
                return _frames.Last();
            }
        }

        public ScopeData()
        {
            this._frames = new ObservableCollection<ScopeDataFrame>();
            this._frames.CollectionChanged += OnFramesPropertyChanged;
        }

        public void OnFramesPropertyChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            this.RaisePropertyChanged(nameof(Frames));
            this.RaisePropertyChanged(nameof(MostRecentFrame));
        }
    }
}
