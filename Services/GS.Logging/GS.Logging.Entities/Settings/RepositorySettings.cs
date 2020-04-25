using System.Collections.Generic;

namespace GS.Logging.Entities.Settings
{
    public class RepositorySettings
    {
        public string LoggerName { get;set;}
        public List<LoggingTarget> Targets {get;set;}

        public RepositorySettings()
        {
            Targets = new List<LoggingTarget>();
        }
    }
}