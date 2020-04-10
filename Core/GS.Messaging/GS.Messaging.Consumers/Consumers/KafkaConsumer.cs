using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Confluent.Kafka;
using GS.Messaging.Entities;
using GS.Messaging.Entities.Consumers;
using NLog;

namespace GS.Messaging.Consumers.Consumers
{
    public class KafkaConsumer : Consumer
    {
        private ConsumerConfig _settings;
        private KafkaConsumerClientBuilder _builder;
        private Lazy<IConsumer<string, string>> _consumer;

        public KafkaConsumer(ConsumerSettings settings, KafkaConsumerClientBuilder builder, LogFactory logFactory) : base(settings, logFactory)
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

        public override T Consume<T>()
        {
            try
            {
                var result = _consumer.Value.Consume();
                string message = result.Message.Value;
                return JsonSerializer.Deserialize<T>(message);
            }
            catch(Exception ex)
            {
                Logger.Error(ex);
                return default(T);
            }
        }

        public override void Subscribe(Topic topic)
        {
            try
            {
                if(validateTopic(topic))
                {
                    _consumer.Value.Subscribe(topic.Name);
                }
            }
            catch(Exception ex)
            {
                Logger.Error(ex);
            }
        }

        public override void Subscribe(IEnumerable<Topic> topics)
        {
            try
            {
                foreach(var topic in topics)
                {
                    Subscribe(topic);
                }
            }
            catch(Exception ex)
            {
                Logger.Error(ex);
            }
        }

        public override void Subscribe(SubscriptionRequest request)
        {
            try
            {
                if(request.Topics != null && request.Topics.Any())
                {
                    Subscribe(request.Topics);
                }
            }
            catch(Exception ex)
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
        }

        private bool validateTopic(Topic topic)
        {   
            if(topic == null)
            {
                Logger.Error("Topic validation error, topic is NULL");
                return false;
            }

            if(false == string.IsNullOrEmpty(topic.Name))
            {
                Logger.Error("Topic validation error, topic name was not found");
                return false;
            }

            return true;
        }
    }
}