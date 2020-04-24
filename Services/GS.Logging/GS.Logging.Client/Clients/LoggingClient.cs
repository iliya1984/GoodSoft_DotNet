using System.Threading.Tasks;
using GS.Core.Logging.Interfaces;
using GS.Logging.Client.Entities;

namespace GS.Logging.Client.Clients
{
    internal class LoggingClient : AbsLoggingClient
    {
        public LoggingClient(ICoreLoggerFactory loggerFactory, LoggingClientSettings settings) : base(loggerFactory, settings)
        {

        }

        public override Task ErrorAsync(string errorMessage, string stackTrace, object data = null)
        {
            throw new System.NotImplementedException();
        }

        public override Task InfoAsync(string text, object data = null)
        {
            throw new System.NotImplementedException();
        }

        public override Task WarningAsync(string text, object data = null)
        {
            throw new System.NotImplementedException();
        }
    }
}