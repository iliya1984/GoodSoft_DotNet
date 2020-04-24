using System;
using Autofac;
using GS.Core.Logging;
using GS.Core.Logging.Interfaces;
using GS.Core.Messaging.Producers;
using GS.Core.Messaging.Producers.Interfaces;
using GS.Logging.Client.Clients;
using GS.Logging.Client.Entities;
using GS.Logging.Client.Interfaces;
using Microsoft.Extensions.Configuration;

namespace GS.Logging.Client.DI
{
    public class LoggingClientDIModule : Module
    {
        private IConfiguration _configuration;

        public LoggingClientDIModule(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterCoreLoggingModule(_configuration);
            builder.RegisterProducersModule(_configuration);

            builder
                .Register(c =>
                {
                    var loggerFactory = c.Resolve<ICoreLoggerFactory>();
                    try
                    {
                        return new LoggingConfigurationManager(_configuration, loggerFactory);
                    }
                    catch(Exception ex)
                    {
                        loggerFactory.GetLoggerForType<LoggingClientDIModule>().Error(ex);
                        return null;
                    }
                })
                .As<ILoggingConfigurationManager>();


            builder
                .Register( c =>
                {
                    var loggerFactory = c.Resolve<ICoreLoggerFactory>();
                    try
                    {
                        var producerFactory = c.Resolve<IProducerFactory>();
                        Func<LoggingClientSettings, ILoggingClient> factory = settings =>
                        {
                            if(settings.IsAsync)
                            {
                                
                                return new AsyncLoggingClient(loggerFactory, producerFactory, settings);
                            }
                            else
                            {
                               return new LoggingClient(loggerFactory, settings);
                            }
                        };

                        var configurationManager = c.Resolve<ILoggingConfigurationManager>();
                        return new LoggingFactory(factory, configurationManager, loggerFactory);
                    }
                    catch(Exception ex)
                    {
                        loggerFactory.GetLoggerForType<LoggingClientDIModule>().Error(ex);
                        return null;
                    }
                })
                .As<ILoggingFactory>();
        }
    }
}