namespace GS.Core.Messaging.Entities.Interfaces
{
    public interface IConsumeResult<T> : IMessagingResult
    {
         T Value { get; set;}
    }
}