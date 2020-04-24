using System.Threading.Tasks;
using GS.Core.Logging.Interfaces;
using GS.Logging.Client.Entities;
using GS.Logging.Client.Interfaces;

namespace GS.Logging.Client.Clients
{
    internal abstract class AbsLoggingClient : ILoggingClient
    {
         protected ICoreLogger Logger { get; private set;}
         protected LoggingClientSettings Settings { get; private set;}

         protected AbsLoggingClient(ICoreLoggerFactory loggerFactory, LoggingClientSettings settings)
         {
             Logger = loggerFactory.GetLoggerForType(this.GetType());
             Settings = settings;
         }

        public abstract Task ErrorAsync(string errorMessage, string stackTrace = null, object data = null);
        public abstract Task InfoAsync(string text, object data = null);
        public abstract Task WarningAsync(string text, object data = null);
    }
}