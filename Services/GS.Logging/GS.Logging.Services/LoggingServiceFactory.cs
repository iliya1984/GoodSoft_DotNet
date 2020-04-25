using System;
using GS.Core.Logging.Interfaces;
using GS.Logging.Entities.Modules;
using GS.Logging.Entities.Settings;
using GS.Logging.Services.Interfaces;

namespace GS.Logging.Services
{
    public class LoggingServiceFactory : ILoggingServiceFactory
    {
         Func<LoggerMetadata, LoggingModule, ILoggingService> _factory;
        public ICoreLogger _logger;

        public LoggingServiceFactory(
            Func<LoggerMetadata, LoggingModule, ILoggingService> factory, 
            ICoreLoggerFactory loggerFactory)
        {
            _factory = factory;
            _logger = loggerFactory.GetLoggerForType<LoggingServiceFactory>();
        }

        public ILoggingService CreateService(LoggerMetadata metadata, LoggingModule module)
        {
            try
            {
                return _factory.Invoke(metadata, module);
            }
            catch(Exception ex)
            {
                _logger.Error(ex);
                return null;
            }
        }
    }
}