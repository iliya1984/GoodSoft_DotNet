using GS.Logging.Entities.Records;

namespace GS.Logging.Entities.Messages
{
    public class ErrorLogMessage : AbsLogMessage
    {
        public ErrorRecord ErrorRecord { get; set;}
    }
}