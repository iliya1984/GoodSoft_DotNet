using GS.Core.Messaging.Entities.Consumers;
using GS.Core.Messaging.Consumers.Interfaces;

namespace GS.Core.Messaging.Consumers.Interfaces
{
    public interface IConsumerFactory
    {
         IConsumer CreateConsumer(ConsumerSettings settings);
    }
}