using GS.Core.Messaging.Entities.Common;
using GS.Core.Messaging.Entities.Interfaces;

namespace GS.Core.Messaging.Entities.Consumers
{
    public class ConsumeResult<T> : MessagingResult, IConsumeResult<T>
    {
        public ConsumeResult() : base(EMessaging.Action.Consume)
        {
        }

        public T Value {get; set; }
        public bool IsEmpty { get; set; }
    }
}