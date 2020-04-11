using System;
using Confluent.Kafka;
using NLog;

namespace GS.Messaging.Producers.Producers
{
    public class KafkaProducerClientBuilder
    {
        private Func<ProducerConfig, ProducerBuilder<string, string>> _factory;
        private ILogger _logger;

        public KafkaProducerClientBuilder(Func<ProducerConfig, ProducerBuilder<string, string>> factory, LogFactory loggerFactory)
        {
            _factory = factory;
            _logger = loggerFactory.GetCurrentClassLogger();
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