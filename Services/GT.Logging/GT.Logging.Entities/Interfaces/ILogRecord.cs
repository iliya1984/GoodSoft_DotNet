namespace GT.Logging.Entities.Interfaces
{
    public interface ILogRecord
    {
        ELogs.Severity Severity { get;}
        string Message { get; set;}
        object Data { get; set;}
    }
}