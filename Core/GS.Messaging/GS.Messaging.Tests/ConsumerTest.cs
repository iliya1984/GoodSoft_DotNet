using System;
using Xunit;
using Autofac;
using GS.Messaging.Consumers.Configuration;
using GS.Messaging.Consumers.Interfaces;
using GS.Messaging.Entities;

namespace GS.Messaging.Tests
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
            var consumer = consumerFactory.CreateConsumer(settings);
            
            var topic = new Topic
            {
                Id = "1",
                Name = "kafka-test-topic"     
            };

            //Act
            consumer.Subscribe(topic);
            string message = consumer.Consume<string>();

            //Assert
            Assert.Equal(message, "kafka test success");
        }
    }
}
