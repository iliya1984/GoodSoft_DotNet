using Autofac;
using GS.Core.Logging.DI;
using GS.Core.Messaging.Consumers.DI;
using GS.Logging.Api.Hosting;
using GS.Logging.Services.DI;
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
            builder.RegisterModule( new ServicesDIModule(_configuration));

            builder
                .RegisterType<LoggingBackgroundService>()
                .AsSelf();
        }
    }
}