using System.Threading;
using System.Threading.Tasks;

namespace GS.Logging.Client.Interfaces
{
    public interface ILoggingClient
    {
         Task ErrorAsync(string errorMessage, string stackTrace = null, object data = null, CancellationToken cancellationToken = default(CancellationToken));
         Task InfoAsync(string text, object data = null, CancellationToken cancellationToken = default(CancellationToken));
         Task WarningAsync(string text, object data = null, CancellationToken cancellationToken = default(CancellationToken));
    }
}