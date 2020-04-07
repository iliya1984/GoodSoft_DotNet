using GS.Logging.Entities.Interfaces;
using GS.Logging.Entities.Records;
using GS.Logging.Repositories.Interfaces;

namespace GS.Logging.Repositories.Repositories
{
    public abstract class Logger : ILogger
    {
        public void LogError(string errorMessage, string errorStackTrace = null, object data = null)
        {
            var record = new ErrorRecord();
            record.Message = errorMessage;
            record.StackTrace = errorStackTrace;
            record.Data = data;

            WriteLogError(record);
        }

        public void LogInfo(string textMessage, object data = null)
        {
            throw new System.NotImplementedException();
        }

        public void LogWarning(string textMessage, object data = null)
        {
            throw new System.NotImplementedException();
        }

        protected virtual void WriteLog(ILogRecord record)
        {

        }

        protected abstract void WriteLogInfo(ILogRecord record);

        protected abstract void WriteLogWorning(ILogRecord record);

        protected abstract void WriteLogError(IErrorRecord record);
    }
}