using System;
using System.Linq;
using System.Threading.Tasks;
using GS.Core.Logging.Interfaces;
using GS.Logging.Entities;
using GS.Logging.Entities.Interfaces;
using GS.Logging.Entities.Interfaces.Records;
using GS.Logging.Entities.Settings;
using GS.Logging.Repositories.Interfaces;
using NLog;
using NLog.Common;
using NLog.Config;
using NLog.Targets;

namespace GS.Logging.Repositories.Repositories
{
    public class NLogLoggingRepository : LoggingRepository
    {

        private LogFactory _factory;
        private Logger _logger;

        public NLogLoggingRepository(LogFactory factory, ICoreLoggerFactory loggerFactory) : base(loggerFactory)
        {
            _factory = factory;
        }

        public override void Initialize(RepositorySettings settings)
        {
            base.Initialize(settings);

            string loggerName = settings.LoggerName;
            if (string.IsNullOrEmpty(loggerName))
            {
                loggerName = "DefaultLogger";
            }

            _logger = _factory.GetLogger(loggerName);
        }

        protected override void WriteErrorLog(IErrorRecord record)
        {
            foreach (var target in Settings.Targets)
            {
                var logEvent = new LogEventInfo();

                logEvent.LoggerName = Settings.LoggerName + "_Error";
                logEvent.Level = LogLevel.Error;
                logEvent.Message = record.Message;
                logEvent.Properties["CustomFolderName"] = target.Directory;
                logEvent.Properties["Extension"] = getFileExtensionForTarget(target);
                _logger.Log(logEvent);

            }
        }



        protected override void WriteInfoLog(ILogRecord record)
        {
            var logRecord = (LogRecord)record;

            foreach (var target in Settings.Targets)
            {
                var logEvent = new LogEventInfo();
                logEvent.LoggerName = Settings.LoggerName + "_Info";
                logEvent.Level = LogLevel.Info;
                logEvent.Message = logRecord.Message;
                logEvent.Properties["CustomFolderName"] = target.Directory;
                logEvent.Properties["Extension"] = getFileExtensionForTarget(target);
                _logger.Log(logEvent);
            }
        }

        protected override void WriteWarningLog(ILogRecord record)
        {
            var logRecord = (LogRecord)record;

            foreach (var target in Settings.Targets)
            {
                var logEvent = new LogEventInfo();
                logEvent.LoggerName = Settings.LoggerName + "_Warning";
                logEvent.Level = LogLevel.Warn;
                logEvent.Message = logRecord.Message;
                logEvent.Properties["CustomFolderName"] = target.Directory;
                logEvent.Properties["Extension"] = getFileExtensionForTarget(target);
                _logger.Log(logEvent);
            }
        }

        private string getFileExtensionForTarget(LoggingTarget target)
        {
            string extension = "txt";
            switch (target.Format)
            {
                case ELogs.TargetFormat.Text:
                    extension = "log";
                    break;
            }

            return extension;
        }
    }
}