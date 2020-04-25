using GS.Logging.Entities.Records;

namespace GS.Logging.Entities.Messages
{
    public class ErrorLogMessage : AbsLogMessage
    {
        public string StackTrace { get;set; }
        public string Message { get; set;}

        public ErrorLogMessage() : base(ELogs.Severity.Error)
        {
            
        }
    }
}