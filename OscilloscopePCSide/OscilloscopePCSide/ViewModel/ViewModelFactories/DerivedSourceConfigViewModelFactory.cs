using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OscilloscopePCSide.ViewModel.ViewModelFactories
{
    public class DerivedSourceConfigViewModelFactory : IDerivedSourceConfigViewModelFactory
    {
        public IDerivedSourceConfigViewModel Create(ISourcesTabViewModel sourcesTabViewModel, string name, string colorName)
        {
            // note that while sourcesTabViewModel should be the same for all instances, adding it to the constructor for the factory would create a circular dependency
            return new DerivedSourceConfigViewModel(sourcesTabViewModel, name, colorName);
        }
    }
}
