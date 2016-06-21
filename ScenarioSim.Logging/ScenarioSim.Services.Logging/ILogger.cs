using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScenarioSim.Services.Logging
{
    public interface ILogger
    {
        void Write(string message, LoggingLevel level);
        void LogException(Exception ex);
    }
}
