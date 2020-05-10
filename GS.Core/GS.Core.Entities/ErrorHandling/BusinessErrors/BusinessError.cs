namespace GS.Core.Entities.ErrorHandling.BusinessErrors
{
    public class BusinessError
    {
        public string Message { get; private set; }
        public int Code { get; set; }
        public string Source { get; set; }

        public BusinessError(string message)
        {
            Message = message;
        }
    }
}