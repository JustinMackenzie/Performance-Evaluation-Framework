using System;
using NLog;
using ScenarioSim.Services.Logging;
using ILogger = ScenarioSim.Services.Logging.ILogger;

namespace ScenarioSim.Infrastructure.Logging.NLog
{
    public class NLogLogger : ILogger
    {
        /// <summary>
        /// The NLog logger name.
        /// </summary>
        private const string LoggerName = "Logger";

        /// <summary>
        /// The NLog logger.
        /// </summary>
        private readonly Logger logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="NLogLogger"/> class.
        /// </summary>
        public NLogLogger()
        {
            logger = LogManager.GetLogger(LoggerName);
        }

        /// <summary>
        /// Writes the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="level">The level.</param>
        public void Write(string message, LoggingLevel level)
        {
            logger.Log(GetLogLevel(level), message);
        }

        /// <summary>
        /// Logs the exception.
        /// </summary>
        /// <param name="ex">The ex.</param>
        public void LogException(Exception ex)
        {
            logger.Log(LogLevel.Error, ex);
        }

        /// <summary>
        /// Gets the NLog level.
        /// </summary>
        /// <param name="level">The level.</param>
        /// <returns></returns>
        private LogLevel GetLogLevel(LoggingLevel level)
        {
            switch (level)
            {
                case LoggingLevel.Info:
                    return LogLevel.Info;
                case LoggingLevel.Debug:
                    return LogLevel.Debug;
                case LoggingLevel.Trace:
                    return LogLevel.Trace;
                case LoggingLevel.Warning:
                    return LogLevel.Warn;
                case LoggingLevel.Error:
                    return LogLevel.Error;
                default:
                    return LogLevel.Info;
            }
        }
    }
}
