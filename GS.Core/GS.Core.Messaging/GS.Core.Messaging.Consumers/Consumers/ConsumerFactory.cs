using System;
using GS.Core.Logging.Interfaces;
using GS.Core.Messaging.Consumers.Interfaces;
using GS.Core.Messaging.Entities.Consumers;
using NLog;

namespace GS.Core.Messaging.Consumers.Consumers
{
    internal class ConsumerFactory : IConsumerFactory
    {
        private readonly Func<ConsumerSettings, IConsumer> _factory;
        private ICoreLogger _logger;
        private IConsumerConfigurationManager _configurationManager;

        public ConsumerFactory(Func<ConsumerSettings, IConsumer> factory, IConsumerConfigurationManager configurationManager, ICoreLoggerFactory logFactory)
        {
            _factory = factory;
            _configurationManager = configurationManager;
            _logger = logFactory.GetLoggerForType<ConsumerFactory>();
        }

        public IConsumer CreateConsumer()
        {
            try
            {
                var settings = _configurationManager.GetSettings();
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