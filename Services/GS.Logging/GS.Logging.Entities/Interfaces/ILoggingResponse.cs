namespace GS.Logging.Entities.Interfaces
{
    public interface ILoggingResponse
    {
         int RecordsLogged { get; set;}
         bool IsError { get; set;}
    }
}