using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading;
using Confluent.Kafka;
using GS.Core.Logging.Interfaces;
using GS.Core.Messaging.Entities;
using GS.Core.Messaging.Entities.Common;
using GS.Core.Messaging.Entities.Consumers;
using GS.Core.Messaging.Entities.Interfaces;
using NLog;

namespace GS.Core.Messaging.Consumers.Consumers
{
    internal class KafkaConsumer : Consumer
    {
        private const short MaxConsumeTries = 1000;
        private ConsumerConfig _settings;
        private KafkaConsumerClientBuilder _builder;
        private Lazy<IConsumer<string, string>> _consumer;

        public KafkaConsumer(ConsumerSettings settings, KafkaConsumerClientBuilder builder, ICoreLoggerFactory logFactory) : base(settings, logFactory)
        {
            _settings = new ConsumerConfig();
            setConfiguration(_settings, settings);

            _builder = builder;
            _consumer = new Lazy<IConsumer<string, string>>(() =>
            {
                return _builder.Build(_settings);
            },
            true);
        }

        public override IConsumeResult<T> Consume<T>(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public override IConsumeResult<T> Consume<T>(int timeOut)
        {
            try
            {
                var consumer = _consumer.Value;


                T message = default(T);
                var result = consumer.Consume(timeOut);
                
                if(result == null)
                {
                    return new ConsumeResult<T>
                    {
                        IsEmpty = true
                    };
                }
                
                string messageString = result.Message.Value;

                 message = JsonSerializer.Deserialize<T>(messageString);

                return new ConsumeResult<T> { Value = message };


            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return ex.AsConsumeResult<T>();
            }
        }

        public override void Dispose()
        {
            try
            {
                _consumer.Value.Dispose();
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
            }
        }

        public override void Subscribe(Topic topic)
        {
            try
            {
                if (validateTopic(topic))
                {
                    _consumer.Value.Subscribe(topic.Name);
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
            }
        }

        public override void Subscribe(IEnumerable<Topic> topics)
        {
            try
            {
                foreach (var topic in topics)
                {
                    Subscribe(topic);
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
            }
        }

        public override void Subscribe(SubscriptionRequest request)
        {
            try
            {
                if (request.Topics != null && request.Topics.Any())
                {
                    Subscribe(request.Topics);
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
            }
        }

        //Maps generic consumer settings to Kafka consumer settings
        private void setConfiguration(ConsumerConfig kafkaSettings, ConsumerSettings settings)
        {
            var servers = settings.Servers.Select(s => $"{s.Host}:{s.Port}").ToArray();
            kafkaSettings.BootstrapServers = string.Join(",", servers);

            kafkaSettings.GroupId = settings.Group;
            kafkaSettings.SessionTimeoutMs = settings.SessionTimeout;
            kafkaSettings.AutoOffsetReset = AutoOffsetReset.Earliest;
        }

        private bool validateTopic(Topic topic)
        {
            if (topic == null)
            {
                Logger.Error("Topic validation error, topic is NULL");
                return false;
            }

            if (string.IsNullOrEmpty(topic.Name))
            {
                Logger.Error("Topic validation error, topic name was not found");
                return false;
            }

            return true;
        }
    }
}