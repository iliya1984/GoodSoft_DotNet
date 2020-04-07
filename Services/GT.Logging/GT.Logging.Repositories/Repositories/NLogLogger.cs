using GT.Logging.Entities.Interfaces;
using GT.Logging.Repositories.Interfaces;

namespace GT.Logging.Repositories.Repositories
{
    public class NLogLogger : ILogger
    {

        public void LogError(string errorMessage, string errorStackTrace = null, object data = null)
        {
            throw new System.NotImplementedException();
        }

        public void LogInfo(string textMessage, object data = null)
        {
            throw new System.NotImplementedException();
        }

        public void LogWarning(string textMessage, object data = null)
        {
            throw new System.NotImplementedException();
        }

        public void Write(ILogRecord record)
        {
            throw new System.NotImplementedException();
        }
    }
}