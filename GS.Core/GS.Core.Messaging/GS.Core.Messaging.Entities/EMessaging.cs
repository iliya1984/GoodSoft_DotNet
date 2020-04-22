namespace GS.Core.Messaging.Entities
{
    public class EMessaging
    {
        public enum Technology
        {
            None,
            Kafka,
            RabbitMq,
            MsMq
        }

        public enum Action
        {
            None,
            Produce,
            Consume
        }

        public enum ActionResult
        {
            None,
            Ok,
            Error
        }
    }
}