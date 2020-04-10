using System.Threading;
using GS.Messaging.Entities.Interfaces;

namespace GS.Messaging.Entities.Consumers
{
    public class ConsumptionRequest : IConsumptionRequest
    {
        public CancellationToken CancellationToken { get; set;}
    }
}