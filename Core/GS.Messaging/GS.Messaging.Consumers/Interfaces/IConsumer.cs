using System;
using System.Collections.Generic;
using GS.Messaging.Entities;
using GS.Messaging.Entities.Common;
using GS.Messaging.Entities.Consumers;
using GS.Messaging.Entities.Interfaces;

namespace GS.Messaging.Consumers.Interfaces
{
    public interface IConsumer : IDisposable
    {
        EMessaging.Technology Technology { get; }

        void Subscribe(Topic topic);
        void Subscribe(IEnumerable<Topic> topics);
        void Subscribe(SubscriptionRequest request);
        IConsumeResult<T> Consume<T>();

    }
}