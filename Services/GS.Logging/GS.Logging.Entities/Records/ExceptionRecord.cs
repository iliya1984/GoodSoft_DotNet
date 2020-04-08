using GS.Logging.Entities.Interfaces.Records;
using GS.Logging.Entities.Interfaces;
using System;

namespace GS.Logging.Entities.Records
{
    public class ExceptionRecord : LogRecord, IExceptionRecord
    {
        public ExceptionRecord(): base(ELogs.Severity.Error)
        { }

        public Exception Exception { get; set;}
    }
}