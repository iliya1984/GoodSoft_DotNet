namespace GS.Logging.Entities.Interfaces.Records
{
    public class LogRecord : ILogRecord
    {
        public ELogs.Severity Severity { get; set;}
        public string Message { get; set;}
        public object Data { get; set;}

        public LogRecord() { }

        public LogRecord(ELogs.Severity severity)
        {
            Severity = severity;
        }
    }
}