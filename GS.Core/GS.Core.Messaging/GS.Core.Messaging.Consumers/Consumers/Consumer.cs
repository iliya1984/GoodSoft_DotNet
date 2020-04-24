using GS.Core.Messaging.Consumers.Interfaces;
using GS.Core.Messaging.Entities.Consumers;
using GS.Core.Messaging.Entities;
using System.Collections.Generic;
using NLog;
using NLog.Extensions.Logging;
using GS.Core.Messaging.Entities.Common;
using GS.Core.Messaging.Entities.Interfaces;
using GS.Core.Logging.Interfaces;
using System.Threading;

namespace GS.Core.Messaging.Consumers.Consumers
{
    internal abstract class Consumer : IConsumer
    {
        private ConsumerSettings _settings;
        protected ICoreLogger Logger { get; private set; }

        public EMessaging.Technology Technology { get; private set;}

        protected Consumer(ConsumerSettings settings, ICoreLoggerFactory logFactory)
        {
            _settings = settings;

            Technology = _settings.Technology;
            Logger = logFactory.GetLoggerForType(this.GetType());
        }

        public abstract void Subscribe(Topic topic);
        public abstract void Subscribe(IEnumerable<Topic> topics);
        public abstract void Subscribe(SubscriptionRequest request);
        public abstract void Dispose();
        public abstract IConsumeResult<T> Consume<T>(int timeOut);
        public abstract IConsumeResult<T> Consume<T>(CancellationToken cancellationToken);
    }
}