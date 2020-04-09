using System;
using GS.Messaging.Consumers.Interfaces;
using GS.Messaging.Entities.Consumers;
using GS.Messaging.Interfaces;

namespace GS.Messaging.Consumers.Consumers
{
    public class ConsumerFactory : IConsumerFactory
    {
        private readonly Func<ConsumerSettings, IConsumer> _factory;

        public ConsumerFactory(Func<ConsumerSettings, IConsumer> factory)
        {
            _factory = factory;
        }

        public IConsumer CreateConsumer(ConsumerSettings settings)
        {
            try
            {
                return _factory.Invoke(settings);
            }
            catch(Exception ex)
            {
                //TODO: Log error
                return null;
            }
        }
    }
}