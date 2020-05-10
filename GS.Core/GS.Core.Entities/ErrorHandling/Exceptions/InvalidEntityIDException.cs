namespace GS.Core.Entities.ErrorHandling.Exceptions
{
    public class InvalidEntityIDException : InvalidEntityException
    {
        public InvalidEntityIDException(string entityType, string idType) 
            : base(entityType, string.Format($"Invalid entity ID of type { idType }."))
        {
        }
    }
}