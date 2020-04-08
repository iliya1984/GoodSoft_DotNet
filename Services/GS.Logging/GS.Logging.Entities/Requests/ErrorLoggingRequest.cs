namespace GS.Logging.Entities.Requests
{
    public class ErrorLoggingRequest : LoggingRequest
    {
        public string ErrorMessage { get; set;}
        public string ErrorStackTrace { get; set;}
    }
}