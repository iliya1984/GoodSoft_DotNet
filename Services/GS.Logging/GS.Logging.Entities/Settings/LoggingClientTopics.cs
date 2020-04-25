using GS.Core.Messaging.Entities.Common;

namespace GS.Logging.Entities.Settings
{
    public class LoggingClientTopics
    {
        public Topic InfoTopic { get; set;}
        public Topic WarningTopic { get; set;}
        public Topic ErrorTopic { get; set;}
    }
}