using GS.Logging.Client.Entities;

namespace GS.Logging.Client.Interfaces
{
    public interface ILoggingConfigurationManager
    {
         LoggingClientSettings GetSettingsForType<T>(bool isAsync = false);
    }
}