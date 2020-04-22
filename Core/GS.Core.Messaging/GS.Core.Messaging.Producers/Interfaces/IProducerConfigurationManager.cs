using GS.Core.Messaging.Entities.Producers;

namespace GS.Core.Messaging.Producers.Interfaces
{
    public interface IProducerConfigurationManager
    {
         ProducerSettings GetSettings();
    }
}