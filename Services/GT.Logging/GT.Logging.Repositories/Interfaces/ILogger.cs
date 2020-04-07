namespace GT.Logging.Repositories.Interfaces
{
    public interface ILogger
    {
        void LogInfo(string textMessage, object data = null);
        void LogWarning(string textMessage, object data = null);
        void LogError(string errorMessage, string errorStackTrace = null, object data = null);
    }
}