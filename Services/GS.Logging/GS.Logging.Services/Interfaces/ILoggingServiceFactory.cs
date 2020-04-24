using GS.Logging.Entities.Modules;
using GS.Logging.Entities.Settings;

namespace GS.Logging.Services.Interfaces
{
    public interface ILoggingServiceFactory
    {
         ILoggingService CreateService(LoggingSettings settings, LoggingModule module);
    }
}