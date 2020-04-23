using GS.Core.Logging.Interfaces;

namespace GS.Logging.Client.Entities
{
    public class LoggingClientArgs 
    {
        public ICoreLoggerFactory LoggerFactory { get; set; }
    }
}