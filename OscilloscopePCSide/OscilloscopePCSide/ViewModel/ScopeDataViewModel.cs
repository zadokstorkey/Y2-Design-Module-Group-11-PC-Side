using GalaSoft.MvvmLight;
using OscilloscopePCSide.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OscilloscopePCSide.ViewModel
{
    public class ScopeDataViewModel : ViewModelBase, IScopeDataViewModel
    {
        private readonly ScopeData _scopeData;

        public ScopeData ScopeData
        {
            get
            {
                return _scopeData;
            }
        }

        public ScopeDataViewModel(ScopeData scopeData)
        {
            this._scopeData = scopeData;
        }
    }
}
