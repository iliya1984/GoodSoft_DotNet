using System.Threading;
using System.Threading.Tasks;
using GS.Core.Messaging.Entities;
using GS.Core.Messaging.Entities.Common;
using GS.Core.Messaging.Entities.Interfaces;
using GS.Core.Messaging.Entities.Producers;
using GS.Core.Messaging.Producers.Interfaces;
using NLog;

namespace GS.Core.Messaging.Producers.Producers
{
    public abstract class Producer : IProducer
    {
        private ProducerSettings _settings;
        protected ILogger Logger { get; private set; }

        public EMessaging.Technology Technology { get; private set;}

        protected Producer(ProducerSettings settings, LogFactory logFactory)
        {
            _settings = settings;

            Technology = _settings.Technology;
            Logger = logFactory.GetCurrentClassLogger();
        }

        public abstract Task<IMessagingResult> ProduceAsync<T>(Topic topic, string key, T value, CancellationToken cancellationToken);
        public abstract void Dispose();
    }
}