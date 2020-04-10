using System;
using System.Collections.Generic;
using Autofac;
using Confluent.Kafka;
using GS.Messaging.Consumers.Consumers;
using GS.Messaging.Consumers.Interfaces;
using GS.Messaging.Consumers.Services;
using GS.Messaging.Entities.Consumers;
using NLog.Web;

namespace GS.Messaging.Consumers.DI
{
    public class ConsumerDIModule : Module
    {
        public ConsumerDIModule()
        {
        }

        protected override void Load(ContainerBuilder builder)
        {
            var loggerFactory = NLogBuilder.ConfigureNLog("nlog.config");

            builder
                .Register(c => 
                {
                    var config = new List<KeyValuePair<string, string>>();
                    return new ConsumerBuilder<string, string>(config);
                })
                .AsSelf();

            builder
                .Register(c => 
                {
                    var consumerBuilder = c.Resolve<ConsumerBuilder<string, string>>();

                    var factory = new Func<ConsumerSettings, IConsumer>(cs =>
                    {
                        return new KafkaConsumer(cs, consumerBuilder, loggerFactory);
                    });

                    return new ConsumerFactory(factory, loggerFactory);
                })
                .As<IConsumerFactory>();
        }
    }
}