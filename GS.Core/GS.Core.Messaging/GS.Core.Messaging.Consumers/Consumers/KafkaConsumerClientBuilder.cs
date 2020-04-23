using System;
using Confluent.Kafka;
using GS.Core.Logging.Interfaces;
using NLog;

namespace GS.Core.Messaging.Consumers.Consumers
{
    public class KafkaConsumerClientBuilder
    {
        private Func<ConsumerConfig, ConsumerBuilder<string, string>> _factory;
        private ICoreLogger _logger;

        public KafkaConsumerClientBuilder(Func<ConsumerConfig, ConsumerBuilder<string, string>> factory, ICoreLoggerFactory loggerFactory)
        {
            _factory = factory;
            _logger = loggerFactory.GetLoggerForType<KafkaConsumerClientBuilder>();
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