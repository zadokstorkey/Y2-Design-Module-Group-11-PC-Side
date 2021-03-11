using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OscilloscopePCSide.ViewModel
{
    public class MultiProbeDataViewModel : ViewModelBase, IMultiProbeDataViewModel
    {
        private readonly IProbeDataViewModel _probe1ProbeDataViewModel;
        private readonly IProbeDataViewModel _probe2ProbeDataViewModel;

        public IProbeDataViewModel Probe1ProbeDataViewModel
        {
            get
            {
                return _probe1ProbeDataViewModel;
            }
        }

        public IProbeDataViewModel Probe2ProbeDataViewModel
        {
            get
            {
                return _probe2ProbeDataViewModel;
            }
        }

        public MultiProbeDataViewModel(IProbeDataViewModel probe1ProbeDataViewModel, IProbeDataViewModel probe2ProbeDataViewModel)
        {
            this._probe1ProbeDataViewModel = probe1ProbeDataViewModel;
            this._probe2ProbeDataViewModel = probe2ProbeDataViewModel;
        }
    }
}
