using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OscilloscopePCSide.Services
{
    public class ProbeDataParsingService
    {
        public List<int> ParseProbeData(string message)
        {
            return message.Split('|').Where(numstr => numstr != "").Select(numstr => Int32.Parse(numstr)).ToList();
        }
    }
}
