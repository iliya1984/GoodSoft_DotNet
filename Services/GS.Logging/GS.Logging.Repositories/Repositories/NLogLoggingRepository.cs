using System;
using GS.Logging.Entities.Interfaces;
using GS.Logging.Entities.Settings;
using GS.Logging.Repositories.Interfaces;
using NLog;

namespace GS.Logging.Repositories.Repositories
{
    public class NLogLoggingRepository : LoggingRepository
    {
        private LogFactory _factory;
        private Logger _logger;
        private LoggerSettings _settings;

        public NLogLoggingRepository(LogFactory factory, LoggerSettings settings)
        {
            _factory = factory;
            _settings = settings;
            _logger = _factory.GetLogger(_settings.LoggerName);
        }

        protected override void WriteErrorLog(IErrorRecord record)
        {
            try 
            {
                _logger.Error(record.Message);  
            }
            catch(Exception ex)
            {
                _logger.Error(ex, "GT Logger failure. Failed to write error log");
            }
        }

        protected override void WriteExeptionLog(IExceptionRecord record)
        {
            try 
            {
                _logger.Error(record.Exception);  
            }
            catch(Exception ex)
            {
                _logger.Error(ex, "GT Logger failure. Failed to write exception log");
            }
        }

        protected override void WriteInfoLog(ILogRecord record)
        {
            try 
            {
                _logger.Info(record.Message);        
            }
            catch(Exception ex)
            {
                _logger.Error(ex, "GT Logger failure. Failed to write info log");
            }
        }

        protected override void WriteWarningLog(ILogRecord record)
        {
            try 
            {
                _logger.Warn(record.Message);  
            }
            catch(Exception ex)
            {
                _logger.Error(ex, "GT Logger failure. Failed to write warning log");
            }
        }
    }
}