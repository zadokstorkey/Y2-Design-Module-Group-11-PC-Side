using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OscilloscopePCSide.ViewModel
{
    public class SourcesTabViewModel : ViewModelBase, ISourcesTabViewModel
    {
        public ObservableCollection<ISourceConfigViewModel> Sources { get; }

        public SourcesTabViewModel(IEnumerable<ISourceConfigViewModel> sources)
        {
            this.Sources = new ObservableCollection<ISourceConfigViewModel>(sources);
        }
    }
}
