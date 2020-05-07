using System;
using GS.Core.Logging.Entities;
using GS.Core.Logging.Interfaces;
using NLog;

namespace GS.Core.Logging.Loggers
{
    internal class NLogLogger : ICoreLogger
    {
        private LogFactory _factory;
        private ILogger _logger;
        private ILogger _innerLogger;
        private LoggingSettings _settings;

        public NLogLogger(LogFactory factory, LoggingSettings settings)
        {
            _factory = factory;
            _settings = settings;
            _logger = _factory.GetLogger(settings.LoggerName);
            _innerLogger = _factory.GetCurrentClassLogger();
        }

        public void Error(string errorMessage)
        {
            try
            {
                _logger.Error(errorMessage);
            }
            catch(Exception ex)
            {
                _innerLogger.Error(ex);
            }
        }

        public void Error(Exception exception)
        {
            try
            {
                _logger.Error(exception);
            }
            catch(Exception ex)
            {
                _innerLogger.Error(ex);
            }
        }

        public void Info(string text)
        {
            try
            {
                _logger.Info(text);
            }
            catch(Exception ex)
            {
                _innerLogger.Error(ex);
            }
        }

        public void Warning(string warningMessage)
        {
            try
            {
                _logger.Warn(warningMessage);
            }
            catch(Exception ex)
            {
                _innerLogger.Error(ex);
            }
        }

         public void Trace(string traceText)
        {
            try
            {
                _logger.Trace(traceText);
            }
            catch(Exception ex)
            {
                _innerLogger.Error(ex);
            }
        }
    }
}