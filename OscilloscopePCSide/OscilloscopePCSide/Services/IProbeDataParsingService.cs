﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OscilloscopePCSide.Services
{
    public interface IProbeDataParsingService
    {
        List<int> ParseProbeData(string message);
    }
}
