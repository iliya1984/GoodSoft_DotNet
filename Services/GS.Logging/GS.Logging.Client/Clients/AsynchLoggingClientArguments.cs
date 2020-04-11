using GS.Messaging.Entities.Producers;
using GS.Messaging.Producers.Interfaces;
using Microsoft.Extensions.Configuration;
using NLog;

namespace GS.Logging.Client.Clients
{
    public class AsynchLoggingClientArguments
    {
        public IConfiguration Configuration { get; set; }
        public IProducerFactory ProducerFactory { get; set; } 
        public ProducerSettings ProducerSettings { get; set; }
        public LogFactory LogFactory { get; set; }
    }
}