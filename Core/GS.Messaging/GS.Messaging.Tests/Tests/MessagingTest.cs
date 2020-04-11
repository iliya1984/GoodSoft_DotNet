using System.Collections.Generic;
using Autofac;
using GS.Messaging.Consumers.DI;
using GS.Messaging.Producers.DI;
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

            var configurationRoot = new ConfigurationBuilder()
                .AddJsonFile("appSettings.json")
                .Build();


            Builder.RegisterModule(new ConsumerDIModule(configurationRoot));
            Builder.RegisterModule(new ProducerDIModule(configurationRoot));
            Container = Builder.Build();
        }
    }
}