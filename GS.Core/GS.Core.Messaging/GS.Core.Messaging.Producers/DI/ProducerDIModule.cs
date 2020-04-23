using System;
using Autofac;
using Confluent.Kafka;
using GS.Core.Logging.DI;
using GS.Core.Logging.Interfaces;
using GS.Core.Messaging.Entities.Producers;
using GS.Core.Messaging.Producers.Configuration;
using GS.Core.Messaging.Producers.Interfaces;
using GS.Core.Messaging.Producers.Producers;
using Microsoft.Extensions.Configuration;
using NLog;
using NLog.Web;

namespace GS.Core.Messaging.Producers.DI
{
    public class ProducerDIModule : Module
    {
        private IConfiguration _configuration;

        public ProducerDIModule(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule(new CoreLoggingDIModule(_configuration));
            
            builder
                .Register(c => 
                {
                    var loggerFactory = c.Resolve<ICoreLoggerFactory>();
                    try
                    {
                        return new ProducerConfigurationManager(_configuration, loggerFactory);
                    }
                    catch(Exception ex)
                    {
                        loggerFactory.GetLoggerForType<ProducerDIModule>().Error(ex);
                        return null;
                    }
                })
                .As<IProducerConfigurationManager>();


            builder
                .Register(c => 
                {
                    var loggerFactory = c.Resolve<ICoreLoggerFactory>();
                    try
                    {

                        return new KafkaProducerClientBuilder(config =>
                        {
                            return new ProducerBuilder<string, string>(config);
                        }, 
                        loggerFactory);
                    }
                    catch(Exception ex)
                    {
                        loggerFactory.GetLoggerForType<ProducerDIModule>().Error(ex);
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
                        var configurationMananger = c.Resolve<IProducerConfigurationManager>();
                        var consumerBuilder = c.Resolve<KafkaProducerClientBuilder>();
                        var factory = new Func<ProducerSettings, IProducer>(cs =>
                        {
                            return new KafkaProducer(cs, consumerBuilder, loggerFactory);
                        });

                        return new ProducerFactory(factory, configurationMananger, loggerFactory);
                    }
                    catch(Exception ex)
                    {
                        loggerFactory.GetLoggerForType<ProducerDIModule>().Error(ex);
                        return null;
                    }
                })
                .As<IProducerFactory>();
        }
    }
}