using System;
using GS.Core.Logging.Interfaces;
using GS.Core.Messaging.Consumers.Interfaces;
using GS.Core.Messaging.Entities.Consumers;
using NLog;

namespace GS.Core.Messaging.Consumers.Consumers
{
    public class ConsumerFactory : IConsumerFactory
    {
        private readonly Func<ConsumerSettings, IConsumer> _factory;
        private ICoreLogger _logger;

        public ConsumerFactory(Func<ConsumerSettings, IConsumer> factory, ICoreLoggerFactory logFactory)
        {
            _factory = factory;
            _logger = logFactory.GetLoggerForType<ConsumerFactory>();
        }

        public IConsumer CreateConsumer(ConsumerSettings settings)
        {
            try
            {
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