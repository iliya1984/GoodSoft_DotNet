using System.Collections.Generic;

namespace GS.Logging.Entities.Settings
{
    public class LoggerSettings
    {
        public string LoggerName { get;set;}
        public List<LoggingTarget> Targets {get;set;}

        public LoggerSettings()
        {
            Targets = new List<LoggingTarget>();
        }
    }
}