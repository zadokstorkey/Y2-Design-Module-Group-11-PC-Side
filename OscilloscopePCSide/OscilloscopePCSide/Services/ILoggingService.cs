using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OscilloscopePCSide.Services
{
    public interface ILoggingService
    {
        void LogRawCommunication(string rawCommunication);

        void LogCommunication(string communication);
    }
}
