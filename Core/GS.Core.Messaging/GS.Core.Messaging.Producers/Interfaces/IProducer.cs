using System;
using System.Threading;
using System.Threading.Tasks;
using GS.Core.Messaging.Entities.Common;
using GS.Core.Messaging.Entities.Interfaces;

namespace GS.Core.Messaging.Producers.Interfaces
{
    public interface IProducer : IDisposable
    {
        Task<IMessagingResult> ProduceAsync<T>(Topic topic, string key, T value, CancellationToken cancellationToken);
    }
}