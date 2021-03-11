using GalaSoft.MvvmLight;
using OscilloscopePCSide.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OscilloscopePCSide.ViewModel
{
    public class ProbeDataViewModel : ViewModelBase, IProbeDataViewModel
    {
        private readonly ProbeData _probeData;

        public ProbeData ProbeData
        {
            get
            {
                return _probeData;
            }
        }

        public ProbeDataViewModel(ProbeData probeData)
        {
            this._probeData = probeData;
        }
    }
}
