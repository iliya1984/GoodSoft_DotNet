using System;
using Confluent.Kafka;
using GS.Messaging.Entities.Producers;
using NLog;

namespace GS.Messaging.Producers.Producers
{
    public class KafkaProducer : Producer
    {
        private ProducerConfig _settings;
        private KafkaProducerClientBuilder _builder;
        private Lazy<IProducer<string, string>> _producer;

        public KafkaProducer(ProducerSettings settings, KafkaProducerClientBuilder builder, LogFactory logFactory) : base(settings, logFactory)
        {
            _settings = new ProducerConfig();
            setConfiguration(_settings, settings);

            _builder = builder;
            _producer = new Lazy<IProducer<string, string>>(() =>
            {
                return _builder.Build(_settings);
            },
            true);
        }

        private void setConfiguration(ProducerConfig kafkaSettings, ProducerSettings settings)
        {
            throw new NotImplementedException();
        }
    }
}