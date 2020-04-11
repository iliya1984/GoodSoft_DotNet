using GS.Messaging.Consumers.Interfaces;
using GS.Messaging.Entities.Consumers;
using GS.Messaging.Entities;
using System.Collections.Generic;
using NLog;
using NLog.Extensions.Logging;

namespace GS.Messaging.Consumers.Consumers
{
    public abstract class Consumer : IConsumer
    {
        private ConsumerSettings _settings;
        protected ILogger Logger { get; private set; }

        public EMessaging.Technology Technology { get; private set;}

        protected Consumer(ConsumerSettings settings, LogFactory logFactory)
        {
            _settings = settings;

            Technology = _settings.Technology;
            Logger = logFactory.GetCurrentClassLogger();
        }

        public abstract void Subscribe(Topic topic);
        public abstract void Subscribe(IEnumerable<Topic> topics);
        public abstract void Subscribe(SubscriptionRequest request);
        public abstract T Consume<T>();
        public abstract void Dispose();
    }
}