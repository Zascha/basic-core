using System;

namespace WebApplication.Common.Logger
{
    public interface ILogger
    {
        void LogInfo(string message);

        void LogWarning(string message);

        void LogError(string message, Exception exception);

        void LogFatal(string message, Exception exception);
    }
}
