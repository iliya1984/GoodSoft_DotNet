using System;
using System.Threading;
using System.Threading.Tasks;

namespace GS.Logging.Client.Interfaces
{
    public interface ILoggingClient
    {
        void Error(Exception exception, object data = null);
        void Error(string errorMessage, string stackTrace = null, object data = null);

        Task ErrorAsync(Exception exception, object data = null, CancellationToken cancellationToken = default(CancellationToken));
        Task ErrorAsync(string errorMessage, string stackTrace = null, object data = null, CancellationToken cancellationToken = default(CancellationToken));
        Task InfoAsync(string text, object data = null, CancellationToken cancellationToken = default(CancellationToken));
        Task WarningAsync(string text, object data = null, CancellationToken cancellationToken = default(CancellationToken));
    }
}