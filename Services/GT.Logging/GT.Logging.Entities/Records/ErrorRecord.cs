using GT.Logging.Entities.Interfaces;
using GT.Logging.Entities.Interfaces.Records;

namespace GT.Logging.Entities.Records
{
    public class ErrorRecord : LogRecord, IErrorRecord
    {
        public string StackTrace { get;set; }
    
        public ErrorRecord() : base(ELogs.Severity.Error)
        {

        }
    }
}