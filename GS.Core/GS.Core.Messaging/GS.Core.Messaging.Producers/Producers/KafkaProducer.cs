using System;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Confluent.Kafka;
using GS.Core.Logging.Interfaces;
using GS.Core.Messaging.Entities;
using GS.Core.Messaging.Entities.Common;
using GS.Core.Messaging.Entities.Interfaces;
using GS.Core.Messaging.Entities.Producers;
using NLog;

namespace GS.Core.Messaging.Producers.Producers
{
    public class KafkaProducer : Producer
    {
        private ProducerConfig _settings;
        private KafkaProducerClientBuilder _builder;
        private Lazy<IProducer<string, string>> _producer;

        public KafkaProducer(ProducerSettings settings, KafkaProducerClientBuilder builder, ICoreLoggerFactory logFactory) : base(settings, logFactory)
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

        public override void Dispose()
        {
            try
            {
                _producer.Value.Dispose();
            }
            catch(Exception ex)
            {
                Logger.Error(ex);
            }
        }

        public override async Task<IMessagingResult> ProduceAsync<T>(Topic topic, string key, T value, CancellationToken cancellationToken)
        {
            try
            {
                var messageValue = JsonSerializer.Serialize<T>(value);
                var message = new Message<string,string>
                {
                    Key = key,
                    Value = messageValue
                };

                var result = await _producer.Value.ProduceAsync(topic.Name, message, cancellationToken);
                
                return new ProduceResult<T>
                {
                    Key = key,
                    Value = value
                };
            }
            catch(Exception ex)
            {
                Logger.Error(ex);
                return ex.AsProduceResult(key, value);
            }
        }

        private void setConfiguration(ProducerConfig kafkaSettings, ProducerSettings settings)
        {
            var servers = settings.Servers.Select(s => $"{s.Host}:{s.Port}").ToArray();
            kafkaSettings.BootstrapServers = string.Join(",", servers);

        }
    }
}