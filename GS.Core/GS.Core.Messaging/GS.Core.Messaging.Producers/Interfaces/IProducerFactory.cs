using GS.Core.Messaging.Entities.Producers;

namespace GS.Core.Messaging.Producers.Interfaces
{
    public interface IProducerFactory
    {
        IProducer CreateProducer();
    }
}