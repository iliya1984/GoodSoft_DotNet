using GS.Logging.Client.Clients;
using GS.Logging.Entities;

namespace GS.Logging.Tests.Client
{
    public class LoggingTestLoggableAttribute : LoggableAttribute
    {
        public LoggingTestLoggableAttribute() : base("Logging", ELogs.Layer.ClientTest)
        { }
    }
}