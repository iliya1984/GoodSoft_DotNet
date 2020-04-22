using System.Threading;
using GS.Core.Messaging.Entities.Interfaces;

namespace GS.Core.Messaging.Entities.Consumers
{
    public class ConsumptionRequest : IConsumptionRequest
    {
        public CancellationToken CancellationToken { get; set;}
    }
}