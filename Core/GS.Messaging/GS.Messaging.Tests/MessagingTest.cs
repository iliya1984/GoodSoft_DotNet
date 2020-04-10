using Autofac;
using GS.Messaging.Consumers.DI;

namespace GS.Messaging.Tests
{
    public abstract class MessagingTest
    {
        protected IContainer Container;
        protected ContainerBuilder Builder;

        protected MessagingTest()
        {
            Builder = new ContainerBuilder();
            Builder.RegisterModule<ConsumerDIModule>();
            
            Container = Builder.Build();
        }
    }
}