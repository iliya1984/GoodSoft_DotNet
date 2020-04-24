using System;
using System.Collections.Generic;
using Autofac;
using Confluent.Kafka;
using GS.Core.Logging.DI;
using GS.Core.Logging.Interfaces;
using GS.Core.Messaging.Consumers.Configuration;
using GS.Core.Messaging.Consumers.Consumers;
using GS.Core.Messaging.Consumers.Interfaces;
using GS.Core.Messaging.Entities.Consumers;
using Microsoft.Extensions.Configuration;
using NLog;
using NLog.Web;

namespace GS.Core.Messaging.Consumers.DI
{
    public class ConsumerDIModule : Module
    {
        private IConfiguration _configuration;

        public ConsumerDIModule(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void Load(ContainerBuilder builder)
        {
             builder
                .RegisterModule(new CoreLoggingDIModule(_configuration));   

            builder
                .Register(c => 
                {
                    var loggerFactory = c.Resolve<ICoreLoggerFactory>();
                    try
                    {
                        return new ConsumerConfigurationManager(_configuration, loggerFactory);
                    }
                    catch(Exception ex)
                    {
                        loggerFactory.GetLoggerForType<ConsumerDIModule>().Error(ex);
                        return null;
                    }
                })
                .As<IConsumerConfigurationManager>();


            builder
                .Register(c => 
                {
                    var loggerFactory = c.Resolve<ICoreLoggerFactory>();
                    try
                    {
                        return new KafkaConsumerClientBuilder(consumerConfig =>
                        {
                            return new ConsumerBuilder<string, string>(consumerConfig);
                        }, 
                        loggerFactory);
                    }
                    catch(Exception ex)
                    {
                        loggerFactory.GetLoggerForType<ConsumerDIModule>().Error(ex);
                        return null;
                    }
                })
                .AsSelf();

            builder
                .Register(c => 
                {
                    var loggerFactory = c.Resolve<ICoreLoggerFactory>();
                    try
                    {
                        var consumerBuilder = c.Resolve<KafkaConsumerClientBuilder>();
                        var configurationManager = c.Resolve<ConsumerConfigurationManager>();

                        var factory = new Func<ConsumerSettings, IConsumer>(cs =>
                        {
                            return new KafkaConsumer(cs, consumerBuilder, loggerFactory);
                        });

                        return new ConsumerFactory(factory, configurationManager, loggerFactory);
                    }
                    catch(Exception ex)
                    {
                         loggerFactory.GetLoggerForType<ConsumerDIModule>().Error(ex);
                        return null;
                    }
                })
                .As<IConsumerFactory>();
        }
    }
}