using System.Collections.Generic;

namespace GS.Logging.Entities.Settings
{
    public class LoggingSettings
    {
        public string LoggerName { get;set;}
        public List<LoggingTarget> Targets {get;set;}

        public LoggingSettings()
        {
            Targets = new List<LoggingTarget>();
        }
    }
}