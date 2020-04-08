using System;

namespace GS.Logging.Repositories.Interfaces
{
    public interface ILoggingRepository
    {
        void LogInfo(string textMessage, object data = null);
        void LogWarning(string textMessage, object data = null);
        void LogError(string errorMessage, string errorStackTrace = null, object data = null);
        void LogException(Exception exception, object data = null);
    }
}