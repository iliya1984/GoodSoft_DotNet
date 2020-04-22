using System;
using Autofac;
using Confluent.Kafka;
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
        private LogFactory _loggerFactory;
        private ILogger _logger;
        private IConfiguration _configuration;

        public ProducerDIModule(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void Load(ContainerBuilder builder)
        {
             string loggingSettingsFile = _configuration["Messaging:LoggingSettingsFile"];
             
            _loggerFactory = NLogBuilder.ConfigureNLog(loggingSettingsFile);
            _logger = _loggerFactory.GetCurrentClassLogger();

            builder
                .Register(c => 
                {
                    try
                    {
                        return new ProducerConfigurationManager(_configuration, _loggerFactory);
                    }
                    catch(Exception ex)
                    {
                        _logger.Error(ex);
                        return null;
                    }
                })
                .As<IProducerConfigurationManager>();


            builder
                .Register(c => 
                {
                    try
                    {
                        return new KafkaProducerClientBuilder(config =>
                        {
                            return new ProducerBuilder<string, string>(config);
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
                        var configurationMananger = c.Resolve<IProducerConfigurationManager>();
                        var consumerBuilder = c.Resolve<KafkaProducerClientBuilder>();
                        var factory = new Func<ProducerSettings, IProducer>(cs =>
                        {
                            return new KafkaProducer(cs, consumerBuilder, _loggerFactory);
                        });

                        return new ProducerFactory(factory, configurationMananger, _loggerFactory);
                    }
                    catch(Exception ex)
                    {
                        _logger.Error(ex);
                        return null;
                    }
                })
                .As<IProducerFactory>();
        }
    }
}