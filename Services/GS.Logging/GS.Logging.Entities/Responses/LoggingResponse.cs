using GS.Logging.Entities.Interfaces;

namespace GS.Logging.Entities.Responses
{
    public class LoggingResponse : ILoggingResponse
    {
        public int RecordsLogged { get; set;}
        public bool IsError { get; set;}
    }
}