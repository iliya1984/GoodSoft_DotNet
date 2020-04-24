using GS.Core.Messaging.Entities.Consumers;

namespace GS.Core.Messaging.Consumers.Interfaces
{
    public interface IConsumerConfigurationManager
    {
         ConsumerSettings GetSettings();
    }
}