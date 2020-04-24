using GS.Logging.Entities.Modules;

namespace GS.Logging.Client.Entities
{
    public class LoggingClientSettings
    {
        public bool IsAsync { get; set;}
        public string BaseUrl { get; set;}
        public LoggingTopics Topics { get; set; }
        public LoggingModule Module { get; set;}
        public string LoggerName { get; set;}
        public string LoggerFullName { get; set; }
        public string ClassName { get; set; }
        public string ClassFullName { get; set; }

        public LoggingClientSettings()
        {
            Topics = new LoggingTopics();
        }
    }
}