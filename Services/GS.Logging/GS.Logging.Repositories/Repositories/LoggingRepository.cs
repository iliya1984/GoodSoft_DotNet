using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GS.Logging.Entities;
using GS.Logging.Entities.Interfaces;
using GS.Logging.Entities.Interfaces.Records;
using GS.Logging.Entities.Records;
using GS.Logging.Entities.Settings;
using GS.Logging.Repositories.Interfaces;

namespace GS.Logging.Repositories.Repositories
{
    public abstract class LoggingRepository : ILoggingRepository
    {
        protected LoggingSettings Settings;

        public string LoggerName { get; private set;}
        public List<LoggingTarget> Targets { get; private set;}

        public LoggingRepository()
        {
            Targets = new List<LoggingTarget>();
            LoggerName = "LoggingRepository";
        }

        public async Task LogErrorAsync(string errorMessage, string errorStackTrace = null, object data = null)
        {
            var record = new ErrorRecord();
            record.Message = errorMessage;
            record.StackTrace = errorStackTrace;
            record.Data = data;

            await WriteErrorLogAsync(record);
        }

        public async Task LogInfoAsync(string textMessage, object data = null)
        {
            var record = new LogRecord(ELogs.Severity.Info);
            record.Message = textMessage;
            record.Data = data;

            await WriteInfoLogAsync(record);
        }

        public async Task LogWarningAsync(string textMessage, object data = null)
        {
            var record = new LogRecord(ELogs.Severity.Warning);
            record.Message = textMessage;
            record.Data = data;

             await WriteWarningLogAsync(record);
        }

        public async Task LogExceptionAsync(Exception exception, object data = null)
        {
            var record = new ExceptionRecord();
            record.Exception = exception;
            record.Data = data;

            await WriteExeptionLogAsync(record);
        }

        protected abstract Task WriteInfoLogAsync(ILogRecord record);

        protected abstract Task WriteWarningLogAsync(ILogRecord record);

        protected abstract Task WriteErrorLogAsync(IErrorRecord record);
        protected abstract Task WriteExeptionLogAsync(IExceptionRecord record);

        public virtual void Initialize(LoggingSettings settings)
        {
            Settings = settings;
            if(settings != null && false == string.IsNullOrEmpty(settings.LoggerName))
            {
                LoggerName = settings.LoggerName;
            }
        }
    }
}