﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OscilloscopePCSide.ViewModel
{
    public interface ITraceTabViewModelFactory
    {
        ITraceTabViewModel Create(IMultiProbeDataViewModel multiProbeDataViewModel);
    }
}
