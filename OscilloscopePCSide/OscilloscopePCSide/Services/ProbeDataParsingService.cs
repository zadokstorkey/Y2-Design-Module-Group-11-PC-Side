using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OscilloscopePCSide.Services
{
    public class ProbeDataParsingService : IProbeDataParsingService
    {
        public List<int> ParseProbeData(string message)
        {
            return message.Split('|').Where(numstr => numstr != "").Select(numstr => Int32.Parse(numstr) * 4 /* note, the multiplication by 4 is temporary for demonstration purposes*/).ToList();
        }
    }
}
