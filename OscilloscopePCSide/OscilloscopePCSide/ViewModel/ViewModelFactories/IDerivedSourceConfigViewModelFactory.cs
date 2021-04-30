using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OscilloscopePCSide.ViewModel.ViewModelFactories
{
    public interface IDerivedSourceConfigViewModelFactory
    {
        IDerivedSourceConfigViewModel Create(ISourcesTabViewModel sourcesTabViewModel, string name, string colorName);
    }
}
