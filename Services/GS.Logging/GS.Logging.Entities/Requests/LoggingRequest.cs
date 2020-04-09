using System.Collections.Generic;
using GS.Logging.Entities.Interfaces;
using GS.Logging.Entities.Modules;

namespace GS.Logging.Entities.Requests
{
    public class LoggingRequest : ILoggingRequest
    {
        public LoggingModule Module { get; set; }
        public object Data { get; set;}
    }
}