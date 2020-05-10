namespace GS.Core.Api.Entities
{
     public class ExceptionResponse
    {
        public string ExceptionMessage { get; set; }
        public string ExceptionType { get; set; }
        public string StackTrace { get; set; }
        public ExceptionResponse InnerException { get; set;}
    }

}