using System;
using System.Linq;
using System.Threading.Tasks;
using GS.Logging.Entities;
using GS.Logging.Entities.Interfaces;
using GS.Logging.Entities.Settings;
using GS.Logging.Repositories.Interfaces;
using NLog;
using NLog.Config;
using NLog.Targets;

namespace GS.Logging.Repositories.Repositories
{
    public class NLogLoggingRepository : LoggingRepository
    {
        private LogFactory _factory;
        private Logger _logger;

        public NLogLoggingRepository(LogFactory factory)
        {
            _factory = factory;
        }

        public override void Initialize(LoggingSettings settings)
        {
            base.Initialize(settings);

            _logger = _factory.GetLogger(LoggerName);
        }

        protected override async Task WriteErrorLogAsync(IErrorRecord record)
        {
            try
            {
                await Task.Run(() =>
                {
                    foreach (var target in Targets)
                    {
                        var logEvent = new LogEventInfo();
                        logEvent.Level = LogLevel.Error;
                        logEvent.Message = record.Message;
                        logEvent.Properties["CustomFileName"] = target.FileName + "_Error";
                        logEvent.Properties["Extension"] = getFileExtensionForTarget(target);
                        _logger.Log(logEvent);
                    }
                });
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "GT Logger failure. Failed to write error log");
            }
        }

        protected override async Task WriteExeptionLogAsync(IExceptionRecord record)
        {
            try
            {
                await Task.Run(() =>
               {
                   _logger.Error(record.Exception);
               });
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "GT Logger failure. Failed to write exception log");
            }
        }

        protected override async Task WriteInfoLogAsync(ILogRecord record)
        {
            try
            {
                await Task.Run(() =>
                {
                    _logger.Info(record.Message);
                });

            }
            catch (Exception ex)
            {
                _logger.Error(ex, "GT Logger failure. Failed to write info log");
            }
        }

        protected override async Task WriteWarningLogAsync(ILogRecord record)
        {
            try
            {
                await Task.Run(() =>
                {
                    _logger.Warn(record.Message);
                });
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "GT Logger failure. Failed to write warning log");
            }
        }

        private string getFileExtensionForTarget(LoggingTarget target)
        {
            string extension = "txt";
            switch(target.Format)
            {
                case ELogs.TargetFormat.Text:
                    extension =  "log";
                    break;
            }

            return extension;
        }
    }
}