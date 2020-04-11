using System.Threading;
using System.Threading.Tasks;
using GS.Messaging.Entities.Interfaces;

namespace GS.Messaging.Producers.Interfaces
{
    public interface IProducer
    {
        Task<IMessagingResult> ProduceAsync<T>(string key, T value, CancellationToken cancellationToken);
    }
}