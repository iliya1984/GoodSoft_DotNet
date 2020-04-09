using GS.Messaging.Entities.Consumers;
using GS.Messaging.Interfaces;

namespace GS.Messaging.Consumers.Interfaces
{
    public interface IConsumerFactory
    {
         IConsumer CreateConsumer(ConsumerSettings settings);
    }
}