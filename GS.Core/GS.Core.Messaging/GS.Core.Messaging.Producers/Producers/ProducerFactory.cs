using System;
using GS.Core.Logging.Interfaces;
using GS.Core.Messaging.Entities.Producers;
using GS.Core.Messaging.Producers.Configuration;
using GS.Core.Messaging.Producers.Interfaces;
using NLog;

namespace GS.Core.Messaging.Producers.Producers
{
    internal class ProducerFactory : IProducerFactory
    {
        private IProducerConfigurationManager _configurationMananger;
        private readonly Func<ProducerSettings, IProducer> _factory;
        private ICoreLogger _logger;

        public ProducerFactory(Func<ProducerSettings, IProducer> factory, IProducerConfigurationManager configurationMananger, ICoreLoggerFactory logFactory)
        {
            _factory = factory;
            _configurationMananger = configurationMananger;
            _logger = logFactory.GetLoggerForType<ProducerFactory>();
        }

        public IProducer CreateProducer()
        {
            try
            {
                var settings = _configurationMananger.GetSettings();
                var producer = _factory.Invoke(settings);

                return producer;
            }
            catch(Exception ex)
            {
                _logger.Error(ex);
                return null;
            }
        }
    }
}