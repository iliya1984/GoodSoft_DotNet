using System.Threading;
using System.Threading.Tasks;
using GS.Messaging.Entities;
using GS.Messaging.Entities.Common;
using GS.Messaging.Entities.Interfaces;
using GS.Messaging.Entities.Producers;
using GS.Messaging.Producers.Interfaces;
using NLog;

namespace GS.Messaging.Producers.Producers
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
    }
}