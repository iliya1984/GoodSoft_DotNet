using System;
using Xunit;
using Autofac;
using GS.Messaging.Consumers.Configuration;
using GS.Messaging.Consumers.Interfaces;
using GS.Messaging.Entities;
using GS.Messaging.Tests.Entities;
using GS.Messaging.Entities.Common;

namespace GS.Messaging.Tests.Tests
{
    public class ConsumerTest : MessagingTest
    {

        [Fact]
        public void When_Consume_Recieves_Message()
        {
            //Arrange
            var configurationManager = Container.Resolve<ConsumerConfigurationManager>();
            var settings = configurationManager.GetSettings();
            var consumerFactory = Container.Resolve<IConsumerFactory>();
            ;

            var topic = new Topic
            {
                Id = "1",
                Name = "kafka-test-topic"
            };

            using (var consumer = consumerFactory.CreateConsumer(settings))
            {
                //Act
                consumer.Subscribe(topic);
                var message = consumer.Consume<TestMessage>();

                //Assert
                Assert.Equal(message.Value.Text, "Hello from Kafka");
            }
        }
    }
}
