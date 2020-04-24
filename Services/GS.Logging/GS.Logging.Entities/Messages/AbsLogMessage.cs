using GS.Logging.Entities.Interfaces.Records;
using GS.Logging.Entities.Modules;

namespace GS.Logging.Entities.Messages
{
    public abstract class AbsLogMessage
    {
        public string Key { get; set; }
        public ELogs.Severity Severity { get; set;}
        public LoggingModule Module { get; set; }
    }
}