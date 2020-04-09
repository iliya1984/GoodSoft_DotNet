using GS.Messaging.Interfaces;
using GS.Messaging.Entities.Consumers;
using GS.Messaging.Entities;
using System.Collections.Generic;

namespace GS.Messaging.Consumers.Consumers
{
    public abstract class Consumer : IConsumer
    {
        private ConsumerSettings _settings;

        protected Consumer(ConsumerSettings settings)
        {
            _settings = settings;
        }

        public abstract void Subscribe(Topic topic);
        public abstract void Subscribe(IEnumerable<Topic> topics);
        public abstract void Subscribe(SubscriptionRequest request);
        public abstract T Consume<T>();
    }
}