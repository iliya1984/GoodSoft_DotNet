using System;
using GS.Core.Logging.Interfaces;
using GS.Logging.Entities.Modules;
using GS.Logging.Entities.Settings;
using GS.Logging.Services.Interfaces;

namespace GS.Logging.Services
{
    public class LoggingServiceFactory : ILoggingServiceFactory
    {
         Func<LoggingSettings, LoggingModule, ILoggingService> _factory;
        public ICoreLogger _logger;

        public LoggingServiceFactory(
            Func<LoggingSettings, LoggingModule, ILoggingService> factory, 
            ICoreLoggerFactory loggerFactory)
        {
            _factory = factory;
            _logger = loggerFactory.GetLoggerForType<LoggingServiceFactory>();
        }

        public ILoggingService CreateService(LoggingSettings settings, LoggingModule module)
        {
            try
            {
                return _factory.Invoke(settings, module);
            }
            catch(Exception ex)
            {
                _logger.Error(ex);
                return null;
            }
        }
    }
}