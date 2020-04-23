using System;
using GS.Core.Logging.Entities;
using GS.Core.Logging.Interfaces;
using NLog;

namespace GS.Core.Logging
{
    internal class CoreLoggerFactory : ICoreLoggerFactory
    {
        private Func<LoggingSettings, ICoreLogger> _factory;
        private ILogger _innerLogger;
        private ICoreLoggerConfigurationManager _configurationManager;

        public CoreLoggerFactory(
            Func<LoggingSettings, ICoreLogger> factory,
            ICoreLoggerConfigurationManager configurationManager,
            LogFactory logFactory)
        {
            _factory = factory;
            _configurationManager = configurationManager;
            _innerLogger = logFactory.GetCurrentClassLogger();
        }

        public ICoreLogger GetLogger(LoggingSettings settings = null)
        {
            try
            {
                var loggingSettings = settings;
                if (loggingSettings == null)
                {
                    loggingSettings = _configurationManager.GetSettings();
                }

                return _factory.Invoke(loggingSettings);
            }
            catch (Exception ex)
            {
                _innerLogger.Error(ex);
                return null;
            }
        }

        public ICoreLogger GetLoggerForType(Type type, LoggingSettings settings = null)
        {
            try
            {
                var loggingSettings = settings;
                if (loggingSettings == null)
                {
                    loggingSettings = _configurationManager.GetSettings();
                }

                loggingSettings.LoggerName = type.FullName;
                return _factory.Invoke(loggingSettings);
            }
            catch (Exception ex)
            {
                _innerLogger.Error(ex);
                return null;
            }
        }

        public ICoreLogger GetLoggerForType<T>(LoggingSettings settings = null)
        {
            try
            {
                var loggingSettings = settings;
                if (loggingSettings == null)
                {
                    loggingSettings = _configurationManager.GetSettings();
                }

                loggingSettings.LoggerName = typeof(T).FullName;
                return _factory.Invoke(loggingSettings);
            }
            catch (Exception ex)
            {
                _innerLogger.Error(ex);
                return null;
            }
        }
    }
}