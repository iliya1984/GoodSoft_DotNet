using GS.Logging.Entities.Interfaces.Records;
using GS.Logging.Entities.Modules;
using GS.Logging.Entities.Settings;

namespace GS.Logging.Entities.Messages
{
    public abstract class AbsLogMessage
    {
        public string Key { get; set; }
        public ELogs.Severity Severity { get; set;}
        public LoggerMetadata LoggerMetadata { get; set;}
        public LoggingModule Module { get; set; }
        public object Data { get; set;}

        protected AbsLogMessage() {}

        protected AbsLogMessage(ELogs.Severity severity)
        {
            Severity = severity;
        }
    }
}