using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Confluent.Kafka;
using GS.Messaging.Entities;
using GS.Messaging.Entities.Consumers;

namespace GS.Messaging.Consumers.Consumers
{
    public class KafkaConsumer : Consumer
    {
        private ConsumerConfig _settings;
        private string _topicName;
        private ConsumerBuilder<string, string> _builder;
        private Lazy<IConsumer<string, string>> _consumer;

        public KafkaConsumer(ConsumerSettings settings, ConsumerBuilder<string, string> builder) : base(settings)
        {
            _settings = new ConsumerConfig();
            setConfiguration(_settings, settings);

            _builder = builder;
            _consumer = new Lazy<IConsumer<string, string>>(() =>
            {
                return _builder.Build();
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
                //TODO: log error
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
                //TODO: log error
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
                //TODO: log error
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
                //TODO: log error
            }
        }

        //Maps generic consumer settings to Kafka consumer settings
        private void setConfiguration(ConsumerConfig kafkaSettings, ConsumerSettings settings)
        {
            
            
        }

        private bool validateTopic(Topic topic)
        {
            return topic != null && false == string.IsNullOrEmpty(topic.Name);
            //TODO: log validation error
        }
    }
}