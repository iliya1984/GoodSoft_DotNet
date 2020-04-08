using System.Collections.Generic;
using GS.Logging.Entities.Interfaces;
using GS.Logging.Entities.Modules.Settings;

namespace GS.Logging.Entities.Requests
{
    public class LoggingRequest : ILoggingRequest
    {
        public LoggingModule Module { get; set; }
        public List<ILogRecord> Records { get; set;}

        public LoggingRequest()
        {
            Records = new List<ILogRecord>();
        }
    }
}