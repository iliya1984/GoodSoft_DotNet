namespace GT.Logging.Entities.Interfaces.Records
{
    public class LogRecord : ILogRecord
    {
        public ELogs.Severity Severity { get; private set;}
        public string Message { get; set;}
        public object Data { get; set;}

        public LogRecord(ELogs.Severity severity)
        {
            Severity = severity;
        }
    }
}