using System;
using System.Threading;
using System.Threading.Tasks;
using GS.Core.Logging.Interfaces;
using GS.Logging.Entities.Settings;

namespace GS.Logging.Client.Clients
{
    internal class LoggingClient : AbsLoggingClient
    {
        public LoggingClient(ICoreLoggerFactory loggerFactory, LoggingClientSettings settings) : base(loggerFactory, settings)
        {

        }

        public override void Error(Exception exception, object data = null)
        {
            throw new NotImplementedException();
        }

        public override void Error(string errorMessage, string stackTrace = null, object data = null)
        {
            throw new NotImplementedException();
        }

        public override Task ErrorAsync(string errorMessage, string stackTrace, object data = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new System.NotImplementedException();
        }

        public override Task ErrorAsync(Exception exception, object data = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public override Task InfoAsync(string text, object data = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new System.NotImplementedException();
        }

        public override Task WarningAsync(string text, object data = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new System.NotImplementedException();
        }
    }
}