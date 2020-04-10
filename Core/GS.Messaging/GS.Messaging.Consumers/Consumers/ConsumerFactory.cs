using System;
using GS.Messaging.Consumers.Interfaces;
using GS.Messaging.Entities.Consumers;
using GS.Messaging.Interfaces;
using NLog;

namespace GS.Messaging.Consumers.Consumers
{
    public class ConsumerFactory : IConsumerFactory
    {
        private readonly Func<ConsumerSettings, IConsumer> _factory;
        private ILogger _logger;

        public ConsumerFactory(Func<ConsumerSettings, IConsumer> factory, LogFactory logFactory)
        {
            _factory = factory;
            _logger = logFactory.GetCurrentClassLogger();
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