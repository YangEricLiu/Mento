using System;

namespace Mento.Framework.Log
{
    public interface ILog
    {
        void LogDebug(string message);
        void LogError(string message);
        void LogException(Exception ex, LoggingSeverity severity = LoggingSeverity.Error);
        void LogFatal(string message);
        void LogInformation(string message);
        void LogWarning(string message);
    }
}
