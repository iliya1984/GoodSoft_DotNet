using GS.Core.Logging.Entities;

namespace GS.Core.Logging.Interfaces
{
    public interface ICoreLoggerConfigurationManager
    {
         LoggingSettings GetSettings();
    }
}