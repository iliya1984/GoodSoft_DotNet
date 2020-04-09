using System.Collections.Generic;
using GS.Logging.Entities.Modules;

namespace GS.Logging.Entities.Interfaces
{
    public interface ILoggingRequest
    {
        LoggingModule Module { get; set; }
    }
}