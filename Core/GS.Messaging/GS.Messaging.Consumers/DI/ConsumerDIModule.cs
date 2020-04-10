using System;
using System.Collections.Generic;
using Autofac;
using Confluent.Kafka;
using GS.Messaging.Consumers.Configuration;
using GS.Messaging.Consumers.Consumers;
using GS.Messaging.Consumers.Interfaces;
using GS.Messaging.Entities.Consumers;
using Microsoft.Extensions.Configuration;
using NLog;
using NLog.Web;

namespace GS.Messaging.Consumers.DI
{
    public class ConsumerDIModule : Module
    {
        private LogFactory _loggerFactory;
        private ILogger _logger;

        public ConsumerDIModule()
        {
            
        }

        protected override void Load(ContainerBuilder builder)
        {
             var configuration = builder.Build().Resolve<IConfiguration>();
             string loggingSettingsFile = configuration["Messaging:LoggingSettingsFile"];
             
            _loggerFactory = NLogBuilder.ConfigureNLog(loggingSettingsFile);
            _logger = _loggerFactory.GetCurrentClassLogger();

            builder
                .Register(c => 
                {
                    try
                    {
                        return new ConsumerConfigurationManager(configuration, _loggerFactory);
                    }
                    catch(Exception ex)
                    {
                        _logger.Error(ex);
                        return null;
                    }
                })
                .AsSelf();


            builder
                .Register(c => 
                {
                    try
                    {
                        return new KafkaConsumerClientBuilder(consumerConfig =>
                        {
                            return new ConsumerBuilder<string, string>(consumerConfig);
                        }, 
                        _loggerFactory);
                    }
                    catch(Exception ex)
                    {
                        _logger.Error(ex);
                        return null;
                    }
                })
                .AsSelf();

            builder
                .Register(c => 
                {
                    try
                    {
                        var consumerBuilder = c.Resolve<KafkaConsumerClientBuilder>();
                        var factory = new Func<ConsumerSettings, IConsumer>(cs =>
                        {
                            return new KafkaConsumer(cs, consumerBuilder, _loggerFactory);
                        });

                        return new ConsumerFactory(factory, _loggerFactory);
                    }
                    catch(Exception ex)
                    {
                        _logger.Error(ex);
                        return null;
                    }
                })
                .As<IConsumerFactory>();
        }
    }
}