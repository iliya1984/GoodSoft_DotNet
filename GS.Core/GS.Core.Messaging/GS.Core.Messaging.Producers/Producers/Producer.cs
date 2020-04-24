using System.Threading;
using System.Threading.Tasks;
using GS.Core.Logging.Interfaces;
using GS.Core.Messaging.Entities;
using GS.Core.Messaging.Entities.Common;
using GS.Core.Messaging.Entities.Interfaces;
using GS.Core.Messaging.Entities.Producers;
using GS.Core.Messaging.Producers.Interfaces;
using NLog;

namespace GS.Core.Messaging.Producers.Producers
{
    internal abstract class Producer : IProducer
    {
        private ProducerSettings _settings;
        protected ICoreLogger Logger { get; private set; }

        public EMessaging.Technology Technology { get; private set;}

        protected Producer(ProducerSettings settings, ICoreLoggerFactory logFactory)
        {
            _settings = settings;

            Technology = _settings.Technology;
            Logger = logFactory.GetLoggerForType(this.GetType());
        }

        public abstract Task<IMessagingResult> ProduceAsync<T>(Topic topic, string key, T value, CancellationToken cancellationToken);
        public abstract void Dispose();
    }
}