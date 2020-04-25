using GS.Core.Messaging.Entities.Common;

namespace GS.Logging.Entities.Settings
{
    public class LoggingJobItem
    {
        public string Name { get; set; }
        public ELogs.Severity Severity { get; set; }
        public Topic Topic { get; set;}
    }
}