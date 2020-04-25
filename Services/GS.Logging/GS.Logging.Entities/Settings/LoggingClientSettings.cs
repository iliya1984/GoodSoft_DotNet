using GS.Logging.Entities.Modules;

namespace GS.Logging.Entities.Settings
{
    public class LoggingClientSettings
    {
        public bool IsAsync { get; set;}
        public string BaseUrl { get; set;}
        public LoggingClientTopics Topics { get; set; }
        public LoggingModule Module { get; set;}
        public LoggerMetadata LoggerMetadata { get; set;}
        public string ClassName { get; set; }
        public string ClassFullName { get; set; }

        public LoggingClientSettings()
        {
            Topics = new LoggingClientTopics();
        }
    }
}