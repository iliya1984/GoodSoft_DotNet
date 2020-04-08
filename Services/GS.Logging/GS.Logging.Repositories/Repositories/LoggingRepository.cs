using System;
using GS.Logging.Entities;
using GS.Logging.Entities.Interfaces;
using GS.Logging.Entities.Interfaces.Records;
using GS.Logging.Entities.Records;
using GS.Logging.Repositories.Interfaces;

namespace GS.Logging.Repositories.Repositories
{
    public abstract class LoggingRepository : ILoggingRepository
    {
        public void LogError(string errorMessage, string errorStackTrace = null, object data = null)
        {
            var record = new ErrorRecord();
            record.Message = errorMessage;
            record.StackTrace = errorStackTrace;
            record.Data = data;

            WriteErrorLog(record);
        }

        public void LogInfo(string textMessage, object data = null)
        {
            var record = new LogRecord(ELogs.Severity.Info);
            record.Message = textMessage;
            record.Data = data;

            WriteInfoLog(record);
        }

        public void LogWarning(string textMessage, object data = null)
        {
            var record = new LogRecord(ELogs.Severity.Warning);
            record.Message = textMessage;
            record.Data = data;

            WriteWarningLog(record);
        }

        public void LogException(Exception exception, object data = null)
        {
            var record = new ExceptionRecord();
            record.Exception = exception;
            record.Data = data;

        }

        protected abstract void WriteInfoLog(ILogRecord record);

        protected abstract void WriteWarningLog(ILogRecord record);

        protected abstract void WriteErrorLog(IErrorRecord record);
        protected abstract void WriteExeptionLog(IExceptionRecord record);

       
    }
}