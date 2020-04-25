using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GS.Core.Logging.Interfaces;
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
        protected ICoreLogger InnerLogger { get; private set; }
        protected RepositorySettings Settings { get; private set; }

        protected LoggingRepository(ICoreLoggerFactory loggerFactory)
        {
            InnerLogger = loggerFactory.GetLoggerForType(GetType());
        }

        public async Task LogErrorAsync(string errorMessage, string errorStackTrace = null, object data = null)
        {
            try
            {
                var record = new ErrorRecord();
                record.Message = errorMessage;
                record.StackTrace = errorStackTrace;
                record.Data = data;

                await WriteErrorLogAsync(record);
            }
            catch (Exception ex)
            {
                InnerLogger.Error(ex);
            }
        }

        public async Task LogInfoAsync(string textMessage, object data = null)
        {
            try
            {
                var record = new LogRecord(ELogs.Severity.Info);
                record.Message = textMessage;
                record.Data = data;
                await WriteInfoLogAsync(record);
            }
            catch (Exception ex)
            {
                InnerLogger.Error(ex);
            }
        }

        public async Task LogWarningAsync(string textMessage, object data = null)
        {
            try
            {
                var record = new LogRecord(ELogs.Severity.Warning);
                record.Message = textMessage;
                record.Data = data;

                await WriteWarningLogAsync(record);
            }
            catch (Exception ex)
            {
                InnerLogger.Error(ex);
            }


        }

        public async Task LogExceptionAsync(Exception exception, object data = null)
        {
            try
            {
                var record = new ExceptionRecord();
                record.Exception = exception;
                record.Data = data;

                await WriteExeptionLogAsync(record);
            }
            catch (Exception ex)
            {
                InnerLogger.Error(ex);
            }

        }

        protected abstract Task WriteInfoLogAsync(ILogRecord record);
        protected abstract Task WriteWarningLogAsync(ILogRecord record);
        protected abstract Task WriteErrorLogAsync(IErrorRecord record);
        protected abstract Task WriteExeptionLogAsync(IExceptionRecord record);
        public virtual void Initialize(RepositorySettings settings)
        {
            this.Settings = settings;
        }
    }
}