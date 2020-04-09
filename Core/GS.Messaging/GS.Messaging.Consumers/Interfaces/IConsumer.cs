using System.Collections.Generic;
using GS.Messaging.Entities;
using GS.Messaging.Entities.Consumers;

namespace GS.Messaging.Interfaces
{
    public interface IConsumer
    {
        void Subscribe(Topic topic);
        void Subscribe(IEnumerable<Topic> topics);
        void Subscribe(SubscriptionRequest request);

        T Consume<T>();

    }
}