using System.Threading;

namespace GS.Messaging.Entities.Interfaces
{
    public interface IConsumptionRequest
    {
         CancellationToken CancellationToken { get; set;}
    }
}