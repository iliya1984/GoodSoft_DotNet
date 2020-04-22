using System;
using System.Collections.Generic;
using GS.Core.Messaging.Entities;
using GS.Core.Messaging.Entities.Common;
using GS.Core.Messaging.Entities.Consumers;
using GS.Core.Messaging.Entities.Interfaces;

namespace GS.Core.Messaging.Consumers.Interfaces
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