using GS.Logging.Entities.Interfaces.Records;

namespace GS.Logging.Entities.Messages
{
    public class LogMessage : AbsLogMessage
    {
        public LogRecord Record { get; set; }
    }
}