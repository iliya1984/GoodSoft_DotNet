using System;

namespace GS.Core.Entities.ErrorHandling.Exceptions
{
    public class InvalidEntityException: Exception
    {
        private const string ErrorMessagePrefixTempate = "Entity validation error. Entity type: {0}. {1}";
        public string EntityType { get; } 

        public InvalidEntityException(string entityType, string message) 
            : base(string.Format(ErrorMessagePrefixTempate, entityType, message))
        {
            
        }
 
        public InvalidEntityException(string entityType, string message, Exception innerException) 
            : base(string.Format(ErrorMessagePrefixTempate, entityType, message), innerException)
        {
            
        }
    }
}