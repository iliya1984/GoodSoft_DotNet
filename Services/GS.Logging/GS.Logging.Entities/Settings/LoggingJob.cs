using System.Collections.Generic;
using GS.Core.Messaging.Entities.Common;

namespace GS.Logging.Entities.Settings
{
    public class LoggingJob
    {
        public ELogs.LoggingJob JobType { get; set; }
        public string JobName { get; set; }
        public int ConsumeTimeout { get; set; }
        public List<LoggingJobItem> Items { get; set;}

        public LoggingJob()
        {
            Items = new List<LoggingJobItem>();
        }
    }
}