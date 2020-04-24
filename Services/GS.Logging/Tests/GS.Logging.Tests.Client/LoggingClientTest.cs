using Autofac;
using GS.Core.Logging.DI;
using GS.Core.Messaging.Producers.DI;
using Microsoft.Extensions.Configuration;
using GS.Core.Logging;
using GS.Core.Messaging.Producers;
using GS.Core.Helpers.Extensions;
using GS.Logging.Client;

namespace GS.Logging.Tests.Client
{
    public class LoggingClientTest
    {
        protected IContainer createContainer()
        {
            var builder = new ContainerBuilder();

             var configuration = new ConfigurationBuilder()
                .AddJsonFile("appSettings.json")
                .Build();
            
            builder.Modules(mr =>
            {
                mr.RegisterLoggingClient(configuration);
            });
            
            return builder.Build();
        }
    }
}