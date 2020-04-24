using System;
using GS.Core.Logging.Interfaces;
using GS.Logging.Client.Entities;
using GS.Logging.Client.Interfaces;

namespace GS.Logging.Client.Clients
{
    public class LoggingFactory : ILoggingFactory
    {
        private Func<LoggingClientSettings, ILoggingClient> _factory;
        private ILoggingConfigurationManager _configurationManager;
        private ICoreLogger _logger;

        public LoggingFactory(
            Func<LoggingClientSettings, ILoggingClient> factory,
            ILoggingConfigurationManager configurationManager, 
            ICoreLoggerFactory loggerFactory)
        {
            _factory = factory;
            _configurationManager = configurationManager;
            _logger = loggerFactory.GetLoggerForType<LoggingFactory>();
        }

        public ILoggingClient GetAsyncClientByType<T>()
        {
            try
            {
                var settings = _configurationManager.GetSettingsForType<T>(true);
                return _factory.Invoke(settings);
            }
            catch(Exception ex)
            {
                _logger.Error(ex);
                return null;
            }
        }

         public ILoggingClient GetClientByType<T>()
        {
            try
            {
                var settings = _configurationManager.GetSettingsForType<T>(true);
                return _factory.Invoke(settings);
            }
            catch(Exception ex)
            {
                _logger.Error(ex);
                return null;
            }
        }
    }
}