using System;
using GS.Messaging.Entities.Producers;
using GS.Messaging.Producers.Interfaces;
using NLog;

namespace GS.Messaging.Producers.Producers
{
    public class ProducerFactory : IProducerFactory
    {
         private readonly Func<ProducerSettings, IProducer> _factory;
        private ILogger _logger;

        public ProducerFactory(Func<ProducerSettings, IProducer> factory, LogFactory logFactory)
        {
            _factory = factory;
            _logger = logFactory.GetCurrentClassLogger();
        }

        public IProducer CreateProducer(ProducerSettings settings)
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