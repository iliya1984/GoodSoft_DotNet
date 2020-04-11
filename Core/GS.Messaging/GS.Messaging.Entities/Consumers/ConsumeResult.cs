using GS.Messaging.Entities.Common;
using GS.Messaging.Entities.Interfaces;

namespace GS.Messaging.Entities.Consumers
{
    public class ConsumeResult<T> : MessagingResult, IConsumeResult<T>
    {
        public ConsumeResult() : base(EMessaging.Action.Consume)
        {
        }

        public T Value {get; set; }
    }
}