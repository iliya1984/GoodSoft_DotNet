using GS.Core.Messaging.Entities.Common;

namespace GS.Logging.Client.Entities
{
    public class LoggingTopics
    {
        public Topic InfoTopic { get; set;}
        public Topic WarningTopic { get; set;}
        public Topic ErrorTopic { get; set;}
    }
}