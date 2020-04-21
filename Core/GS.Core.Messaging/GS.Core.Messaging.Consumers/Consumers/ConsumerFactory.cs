using System;
using GS.Core.Messaging.Consumers.Interfaces;
using GS.Core.Messaging.Entities.Consumers;
using NLog;

namespace GS.Core.Messaging.Consumers.Consumers
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