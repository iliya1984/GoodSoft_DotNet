using System;
using Confluent.Kafka;
using NLog;

namespace GS.Core.Messaging.Consumers.Consumers
{
    public class KafkaConsumerClientBuilder
    {
        private Func<ConsumerConfig, ConsumerBuilder<string, string>> _factory;
        private ILogger _logger;

        public KafkaConsumerClientBuilder(Func<ConsumerConfig, ConsumerBuilder<string, string>> factory, LogFactory loggerFactory)
        {
            _factory = factory;
            _logger = loggerFactory.GetCurrentClassLogger();
        }

        public IConsumer<string,string> Build(ConsumerConfig config)
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