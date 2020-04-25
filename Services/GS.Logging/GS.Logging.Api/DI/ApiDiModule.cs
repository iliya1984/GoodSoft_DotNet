using System;
using Autofac;
using GS.Core.Logging.DI;
using GS.Core.Logging.Interfaces;
using GS.Core.Messaging.Consumers.DI;
using GS.Core.Messaging.Consumers.Interfaces;
using GS.Logging.Api.Hosting;
using GS.Logging.Api.Interfaces;
using GS.Logging.Services.DI;
using GS.Logging.Services.Interfaces;
using Microsoft.Extensions.Configuration;

namespace GS.Logging.Api.DI
{
    public class ApiDiModule : Module
    {
        private IConfiguration _configuration;

        public ApiDiModule(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule(new CoreLoggingDIModule(_configuration));
            builder.RegisterModule(new ConsumerDIModule(_configuration));
            builder.RegisterModule(new ServicesDIModule(_configuration));

            builder
                .Register(c =>
                {
                    var loggerFactory = c.Resolve<ICoreLoggerFactory>();
                    return new LoggingJobProvider(_configuration, loggerFactory);
                })
                .As<ILoggingJobProvider>();

            builder
                .Register(c =>
                {
                    var loggerFactory = c.Resolve<ICoreLoggerFactory>();
                    try
                    {
                        var toolkit = new LoggingServiceToolkit();
                        toolkit.LoggerFactory = loggerFactory;
                        toolkit.ConsumerFactory = c.Resolve<IConsumerFactory>();
                        toolkit.JobProvider = c.Resolve<ILoggingJobProvider>();
                        toolkit.ServiceFactory = c.Resolve<ILoggingServiceFactory>();
                        return toolkit;
                    }
                    catch (Exception ex)
                    {
                        loggerFactory.GetLoggerForType<ApiDiModule>().Error(ex);
                        return null;
                    }
                })
                .AsSelf();

            builder
                .RegisterType<LoggingBackgroundService>()
                .AsSelf();
            builder
                .RegisterType<ErrorLoggingBackgroundService>()
                .AsSelf();
        }
    }
}