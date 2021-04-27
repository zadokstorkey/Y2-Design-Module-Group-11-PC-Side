using GalaSoft.MvvmLight;
using OscilloscopePCSide.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OscilloscopePCSide.Model
{
    public class ProbeDataFrame : ObservableObject
    {
        private readonly DateTime _timestamp;

        private readonly List<int> _heights;

        public DateTime Timestamp
        { 
            get
            {
                return _timestamp;
            }
        }

        public List<int> Heights
        {
            get
            {
                return _heights;
            }
        }

        public ProbeDataFrame(DateTime timestamp, List<int> heights)
        {
            this._timestamp = timestamp;
            this._heights = heights;
        }
    }
}
