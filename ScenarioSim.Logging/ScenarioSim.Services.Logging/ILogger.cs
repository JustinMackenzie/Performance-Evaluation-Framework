using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScenarioSim.Services.Logging
{
    /// <summary>
    /// An interface used to access the logging service.
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Writes the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="level">The level.</param>
        void Write(string message, LoggingLevel level);

        /// <summary>
        /// Logs the exception.
        /// </summary>
        /// <param name="ex">The ex.</param>
        void LogException(Exception ex);
    }
}
