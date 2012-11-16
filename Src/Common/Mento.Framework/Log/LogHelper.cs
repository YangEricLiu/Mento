using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.Framework;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using Mento.Framework.Constants;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using System.Configuration;

namespace Mento.Framework.Log
{
    /// <summary>
    /// The log utility class.
    /// </summary>
    public static class LogHelper
    {
        /// <summary>
        /// Log exception.
        /// </summary>
        /// <param name="ex">The excption need be logged.</param>
        /// <param name="severity">The severity of this exception, default value is <see cref="LoggingSeverity.Error" />.</param>
        public static void LogException(Exception ex, LoggingSeverity severity = LoggingSeverity.Error)
        {
            string message = new StringBuilder(ex.Message).AppendLine().Append(ex.StackTrace).ToString();

            //Log
            WriteLog(message, severity);
        }

        #region Message
        /// <summary>
        /// Log fatal.
        /// </summary>
        /// <param name="message">The fatal message.</param>
        public static void LogFatal(string message)
        {
            WriteLog(message, LoggingSeverity.Fatal);
        }

        /// <summary>
        /// Log error.
        /// </summary>
        /// <param name="message">The error message.</param>
        public static void LogError(string message)
        {
            WriteLog(message, LoggingSeverity.Error);
        }

        /// <summary>
        /// Log warning.
        /// </summary>
        /// <param name="message">The warning message.</param>
        public static void LogWarning(string message)
        {
            WriteLog(message, LoggingSeverity.Warning);
        }

        /// <summary>
        /// Log information.
        /// </summary>
        /// <param name="message">The information message.</param>
        public static void LogInformation(string message)
        {
            WriteLog(message, LoggingSeverity.Information);
        }

        /// <summary>
        /// Log debug.
        /// </summary>
        /// <param name="message">The debug message.</param>
        public static void LogDebug(string message)
        {
            WriteLog(message, LoggingSeverity.Debug);
        }
        #endregion

        #region Common
        /// <summary>
        /// Check whether need logging according to the severity.
        /// </summary>
        /// <param name="severity">The logging severity.</param>
        /// <returns>true if need logging, else false.</returns>
        private static bool DoesNeedLogging(LoggingSeverity severity)
        {
            LoggingSeverity loggingSeveritySetting = (LoggingSeverity)Enum.Parse(typeof(LoggingSeverity), ConfigurationManager.AppSettings[ConfigurationKey.LOGGING_SEVERITY]);

#if DEBUG
            if (loggingSeveritySetting >= severity)
            {
                return true;
            }
            else
            {
                return false;
            }
#else
            if (loggingSeveritySetting == LoggingSeverity.Fatal || loggingSeveritySetting == LoggingSeverity.Error)
            {
                return true;
            }
            else
            {
                return false;
            }
#endif
        }

        /// <summary>
        /// Write log to log file.
        /// </summary>
        /// <param name="message">The log message which need be logged.</param>
        /// <param name="severity">The error severity.</param>
        /// <param name="requestId">The reqeust id.</param>
        /// <remarks>The title property of <see cref="LogEntry" /> represents the request id.</remarks>
        private static void WriteLog(string message, LoggingSeverity severity, Guid? requestId = null)
        {
            if (DoesNeedLogging(severity))
            {
                LogEntry logEntry = new LogEntry()
                {
                    TimeStamp = DateTime.UtcNow,
                    Message = new StringBuilder(severity.ToString()).Append(ASCII.SPACE).Append(message).ToString(),
                };

                logEntry.Title = String.Empty;

                logEntry.Categories.Add("Log");

                EnterpriseLibraryContainer.Current.GetInstance<LogWriter>().Write(logEntry);
            }
        }
        #endregion
    }
    
    /// <summary>
    /// Logging severity.
    /// </summary>
    public enum LoggingSeverity
    {
        /// <summary>
        /// Log nothing.
        /// </summary>
        Off,

        /// <summary>
        /// Log fatal message.
        /// </summary>
        Fatal,

        /// <summary>
        /// Log error message.
        /// </summary>
        Error,

        /// <summary>
        /// Log warning message.
        /// </summary>
        Warning,

        /// <summary>
        /// Log information message.
        /// </summary>
        Information,

        /// <summary>
        /// Log the process of method invoking、input/output arguments、return value.
        /// </summary>
        Debug
    }
}
