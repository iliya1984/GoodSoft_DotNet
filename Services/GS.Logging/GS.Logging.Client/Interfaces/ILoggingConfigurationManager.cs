using System;
using GS.Logging.Entities.Settings;

namespace GS.Logging.Client.Interfaces
{
    public interface ILoggingConfigurationManager
    {
         LoggingClientSettings GetSettingsForType<T>(bool isAsync = false);
         LoggingClientSettings GetSettingsForType(Type type, bool isAsync = false);
    }
}