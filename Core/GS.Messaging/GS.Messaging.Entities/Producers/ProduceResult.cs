using GS.Messaging.Entities.Common;

namespace GS.Messaging.Entities.Producers
{
    public class ProduceResult<T> : MessagingResult
    {
        public string Key { get; set;}
        public T Value { get; set;}
    
        public ProduceResult() : base(EMessaging.Action.Produce) { }
    }
}