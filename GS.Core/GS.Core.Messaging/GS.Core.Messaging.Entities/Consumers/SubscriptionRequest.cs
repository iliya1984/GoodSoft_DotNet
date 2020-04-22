using System.Collections.Generic;
using GS.Core.Messaging.Entities.Common;

namespace GS.Core.Messaging.Entities.Consumers
{
    public class SubscriptionRequest
    {
        public IEnumerable<Topic> Topics { get; set;}
    }
}