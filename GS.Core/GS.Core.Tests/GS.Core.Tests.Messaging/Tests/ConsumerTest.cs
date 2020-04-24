using System;
using Xunit;
using Autofac;
using GS.Core.Messaging.Consumers.Configuration;
using GS.Core.Messaging.Consumers.Interfaces;
using GS.Core.Messaging.Entities;
using GS.Core.Messaging.Tests.Entities;
using GS.Core.Messaging.Entities.Common;

namespace GS.Core.Messaging.Tests.Tests
{
    public class ConsumerTest : MessagingTest
    {

        [Fact]
        public void When_Consume_Recieves_Message()
        {
            //Arrange
            var consumerFactory = Container.Resolve<IConsumerFactory>();
            ;

            var topic = new Topic
            {
                Id = "1",
                Name = "kafka-test-topic"
            };

            using (var consumer = consumerFactory.CreateConsumer())
            {
                //Act
                consumer.Subscribe(topic);
                var message = consumer.Consume<TestMessage>(30000);

                //Assert
                Assert.Equal(message.Value.Text, "Hello from Kafka");
            }
        }
    }
}
