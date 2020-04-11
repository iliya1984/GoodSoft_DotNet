using System.Collections.Generic;
using Autofac;
using GS.Messaging.Consumers.DI;
using Microsoft.Extensions.Configuration;

namespace GS.Messaging.Tests.Tests
{
    public abstract class MessagingTest
    {
        protected IContainer Container;
        protected ContainerBuilder Builder;

        protected MessagingTest()
        {
            Builder = new ContainerBuilder();

            // var collection = new Dictionary<string, string>
            //         {
            //             { "Messaging:LoggingSettingsFile", "nlog.config" },
            //             { "Messaging:Consumers:ServerBrokers:0:Host", "192.168.1.10" },
            //             { "Messaging:Consumers:ServerBrokers:0:Port", "9092" },
            //              { "Messaging:Consumers:Group", "Test" }

            //         };

            var configurationRoot = new ConfigurationBuilder()
                //.AddInMemoryCollection(collection)
                .AddJsonFile("appSettings.json")
                .Build();


            Builder.RegisterModule(new ConsumerDIModule(configurationRoot));
            Container = Builder.Build();
        }
    }
}