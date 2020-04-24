using System;
using Confluent.Kafka;
using GS.Core.Logging.Interfaces;
using NLog;

namespace GS.Core.Messaging.Producers.Producers
{
    public class KafkaProducerClientBuilder
    {
        private Func<ProducerConfig, ProducerBuilder<string, string>> _factory;
        private ICoreLogger _logger;

        internal KafkaProducerClientBuilder(Func<ProducerConfig, ProducerBuilder<string, string>> factory, ICoreLoggerFactory loggerFactory)
        {
            _factory = factory;
            _logger = loggerFactory.GetLoggerForType<KafkaProducerClientBuilder>();
        }

        public IProducer<string,string> Build(ProducerConfig config)
        {
            try
            {
                var builder = _factory.Invoke(config);
                return builder.Build();
            }
            catch(Exception ex)
            {
                _logger.Error(ex);
                return null;
            }
        }
    }
}