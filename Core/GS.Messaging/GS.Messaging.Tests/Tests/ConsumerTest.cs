using System;
using Xunit;
using Autofac;
using GS.Messaging.Consumers.Configuration;
using GS.Messaging.Consumers.Interfaces;
using GS.Messaging.Entities;
using GS.Messaging.Tests.Entities;

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
                TestMessage message = consumer.Consume<TestMessage>();

                //Assert
                Assert.Equal(message.Text, "kafka test success");
            }
        }
    }
}
