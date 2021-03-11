using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OscilloscopePCSide.ViewModel
{
    public class MultiScopeDataViewModel : ViewModelBase, IMultiScopeDataViewModel
    {
        private readonly IScopeDataViewModel _probe1ScopeDataViewModel;
        private readonly IScopeDataViewModel _probe2ScopeDataViewModel;

        public IScopeDataViewModel Probe1ScopeDataViewModel
        {
            get
            {
                return _probe1ScopeDataViewModel;
            }
        }

        public IScopeDataViewModel Probe2ScopeDataViewModel
        {
            get
            {
                return _probe2ScopeDataViewModel;
            }
        }

        public MultiScopeDataViewModel(IScopeDataViewModel probe1ScopeDataViewModel, IScopeDataViewModel probe2ScopeDataViewModel)
        {
            this._probe1ScopeDataViewModel = probe1ScopeDataViewModel;
            this._probe2ScopeDataViewModel = probe2ScopeDataViewModel;
        }
    }
}
