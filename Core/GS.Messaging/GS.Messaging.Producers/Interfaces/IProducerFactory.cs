using GS.Messaging.Entities.Producers;

namespace GS.Messaging.Producers.Interfaces
{
    public interface IProducerFactory
    {
        IProducer CreateProducer(ProducerSettings settings);
    }
}