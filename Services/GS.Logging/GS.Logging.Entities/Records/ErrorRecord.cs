using GS.Logging.Entities.Interfaces;
using GS.Logging.Entities.Interfaces.Records;

namespace GS.Logging.Entities.Records
{
    public class ErrorRecord : LogRecord, IErrorRecord
    {
        public string StackTrace { get;set; }
    
        public ErrorRecord() : base(ELogs.Severity.Error)
        {

        }
    }
}