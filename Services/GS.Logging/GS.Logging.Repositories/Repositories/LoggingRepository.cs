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

        public void LogError(string errorMessage, string errorStackTrace = null, object data = null)
        {
            try
            {
                var record = new ErrorRecord();
                record.Message = errorMessage;
                record.StackTrace = errorStackTrace;
                record.Data = data;

                WriteErrorLog(record);
            }
            catch (Exception ex)
            {
                InnerLogger.Error(ex);
            }
        }

        public void  LogInfo(string textMessage, object data = null)
        {
            try
            {
                var record = new LogRecord(ELogs.Severity.Info);
                record.Message = textMessage;
                record.Data = data;
                WriteInfoLog(record);
            }
            catch (Exception ex)
            {
                InnerLogger.Error(ex);
            }
        }

        public void  LogWarning(string textMessage, object data = null)
        {
            try
            {
                var record = new LogRecord(ELogs.Severity.Warning);
                record.Message = textMessage;
                record.Data = data;

                WriteWarningLog(record);
            }
            catch (Exception ex)
            {
                InnerLogger.Error(ex);
            }
        }

        protected abstract void WriteInfoLog(ILogRecord record);
        protected abstract void WriteWarningLog(ILogRecord record);
        protected abstract void WriteErrorLog(IErrorRecord record);
        public virtual void Initialize(RepositorySettings settings)
        {
            this.Settings = settings;
        }
    }
}