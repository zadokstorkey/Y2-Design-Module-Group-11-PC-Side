using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace OscilloscopePCSide.Services
{
    public class ProbeDataParsingService : IProbeDataParsingService
    {
        public List<int> ParseProbeData(string message)
        {
            try
            {
                return message.Split('|').Where(numstr => numstr != "").Select(numstr => Int32.Parse(numstr)).ToList();
            }
            catch (Exception e)
            {
                MessageBox.Show("Unknown error whilst parsing message. \n Message was '" + message + "'.");
                throw new ApplicationException("Unknown error whilst parsing message.", e);
            }
        }
    }
}
