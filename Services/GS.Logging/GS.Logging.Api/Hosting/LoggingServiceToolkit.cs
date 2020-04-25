using GS.Core.Logging.Interfaces;
using GS.Core.Messaging.Consumers.Interfaces;
using GS.Logging.Api.Interfaces;
using GS.Logging.Services.Interfaces;

namespace GS.Logging.Api.Hosting
{
    public class LoggingServiceToolkit
    {
        public ILoggingJobProvider JobProvider { get; set;}
        public ILoggingServiceFactory ServiceFactory { get; set;} 
        public IConsumerFactory ConsumerFactory { get; set;} 
        public ICoreLoggerFactory LoggerFactory { get; set;}
    }
}