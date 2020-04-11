using System.Collections.Generic;
using GS.Messaging.Entities.Common;

namespace GS.Messaging.Entities.Consumers
{
    public class SubscriptionRequest
    {
        public IEnumerable<Topic> Topics { get; set;}
    }
}