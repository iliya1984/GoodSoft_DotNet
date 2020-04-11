namespace GS.Messaging.Entities.Common
{
    public class MessagingError
    {
        public string Type { get; set;}
        public string Message { get; set; }
        public string StackTrace { get; set; }
    
        public MessagingError()
        {
            Type  = "CustomError";
        }
    }
}