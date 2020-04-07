namespace GT.Logging.Entities.Interfaces
{
    public interface IErrorRecord : ILogRecord
    {
         string StackTrace { get;set; }
    }
}