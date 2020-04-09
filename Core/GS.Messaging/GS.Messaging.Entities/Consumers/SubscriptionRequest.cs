using System.Collections.Generic;

namespace GS.Messaging.Entities.Consumers
{
    public class SubscriptionRequest
    {
        public IEnumerable<Topic> Topics { get; set;}
    }
}