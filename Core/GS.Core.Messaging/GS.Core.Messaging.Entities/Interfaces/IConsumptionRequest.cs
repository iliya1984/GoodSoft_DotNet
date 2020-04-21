using System.Threading;

namespace GS.Core.Messaging.Entities.Interfaces
{
    public interface IConsumptionRequest
    {
         CancellationToken CancellationToken { get; set;}
    }
}