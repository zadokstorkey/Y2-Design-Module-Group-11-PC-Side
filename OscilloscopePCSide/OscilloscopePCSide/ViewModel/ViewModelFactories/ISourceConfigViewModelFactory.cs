using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OscilloscopePCSide.ViewModel.ViewModelFactories
{
    public interface ISourceConfigViewModelFactory
    {
        ISourceConfigViewModel Create(string name, string colourName, string comPort);
    }
}
