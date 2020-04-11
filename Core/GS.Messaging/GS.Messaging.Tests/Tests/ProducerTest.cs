using System;
using System.Threading;
using System.Threading.Tasks;
using Autofac;
using GS.Messaging.Entities;
using GS.Messaging.Entities.Common;
using GS.Messaging.Entities.Interfaces;
using GS.Messaging.Producers.Configuration;
using GS.Messaging.Producers.Interfaces;
using GS.Messaging.Tests.Entities;
using Xunit;

namespace GS.Messaging.Tests.Tests
{
    public class ProducerTest : MessagingTest
    {
        [Fact]
        public void When_Produce_Message_GetSuccess()
        {
            //Arrange
            var configurationManager = Container.Resolve<ProducerConfigurationManager>();
            var settings = configurationManager.GetSettings();
            var factory = Container.Resolve<IProducerFactory>();
            var key = Guid.NewGuid().ToString();
            var value = new TestMessage
            {
                Text = $"New produced message, key = {key}"
            };

            var topic = new Topic
            {
                Id = "1",
                Name = "kafka-test-topic"
            };

            var cancellationToken = new CancellationToken();
            using (var producer = factory.CreateProducer(settings))
            {
                //Act
                IMessagingResult result = default(IMessagingResult); 
                var task = Task.Run(async () =>
                {
                   result = await producer.ProduceAsync(topic, key, value, cancellationToken);
                });
                //result = producer.ProduceAsync(topic, key, value, cancellationToken).Result;
                task.Wait();

                //Assert
                Assert.Equal(result.Result, EMessaging.ActionResult.Ok);
            }
        }
    }
}