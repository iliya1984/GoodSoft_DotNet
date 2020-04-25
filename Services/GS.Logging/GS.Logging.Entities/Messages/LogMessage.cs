using GS.Logging.Entities.Interfaces.Records;

namespace GS.Logging.Entities.Messages
{
    public class LogMessage : AbsLogMessage
    {
        public string Text { get; set;}
        public object Data { get; set;}

        public LogMessage() {}

        public LogMessage(ELogs.Severity severity): base(severity) {}
    }
}