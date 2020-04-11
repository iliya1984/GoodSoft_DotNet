using System;
using System.Collections.Generic;
using GS.Messaging.Entities;
using GS.Messaging.Entities.Consumers;

namespace GS.Messaging.Consumers.Interfaces
{
    public interface IConsumer : IDisposable
    {
        EMessaging.Technology Technology { get; }

        void Subscribe(Topic topic);
        void Subscribe(IEnumerable<Topic> topics);
        void Subscribe(SubscriptionRequest request);

        T Consume<T>();

    }
}