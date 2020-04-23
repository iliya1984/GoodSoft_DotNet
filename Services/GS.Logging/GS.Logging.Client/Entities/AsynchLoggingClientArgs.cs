using GS.Core.Logging.Interfaces;
using GS.Core.Messaging.Entities.Producers;
using GS.Core.Messaging.Producers.Interfaces;
using Microsoft.Extensions.Configuration;
using NLog;

namespace GS.Logging.Client.Entities
{
    public class AsynchLoggingClientArgs 
    {
        public IProducerFactory ProducerFactory { get; set; } 
        public ICoreLoggerFactory LoggerFactory { get; set; }
    }
}