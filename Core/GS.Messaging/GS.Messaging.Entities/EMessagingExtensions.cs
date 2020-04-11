using System;
using System.Collections.Generic;
using GS.Messaging.Entities.Common;
using GS.Messaging.Entities.Consumers;
using GS.Messaging.Entities.Interfaces;
using GS.Messaging.Entities.Producers;

namespace GS.Messaging.Entities
{
    public static class EMessagingExtensions
    {
        public static MessagingError AsMessagingError(this Exception ex)
        {
            if (ex == null)
            {
                return null;
            }

            return new MessagingError
            {
                Message = ex.Message,
                StackTrace = ex.StackTrace,
                Type = ex.GetType().Name
            };
        }

        public static IConsumeResult<T> AsConsumeResult<T>(this Exception ex)
        {
            if (ex == null)
            {
                return null;
            }

            return new ConsumeResult<T>
            {
                Errors = new List<MessagingError>
                    {
                        ex.AsMessagingError()
                    }

            };
        }

        public static IMessagingResult AsProduceResult<T>(this Exception ex, string key, T value)
        {
            return new ProduceResult<T>
            {
                Key = key,
                Value = value,
                Errors = new List<MessagingError>
                    {
                        ex.AsMessagingError()
                    }
            };
        }
    }
}