using GS.Logging.Entities.Interfaces;
using GS.Logging.Repositories.Interfaces;

namespace GS.Logging.Repositories.Repositories
{
    public class NLogLogger : ILoggingRepository
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