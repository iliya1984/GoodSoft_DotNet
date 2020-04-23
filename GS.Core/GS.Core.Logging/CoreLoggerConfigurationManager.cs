using System;
using GS.Core.Logging.Entities;
using GS.Core.Logging.Interfaces;
using Microsoft.Extensions.Configuration;

namespace GS.Core.Logging
{
    internal class CoreLoggerConfigurationManager : ICoreLoggerConfigurationManager
    {
        private IConfiguration _configuration;

        public CoreLoggerConfigurationManager(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public LoggingSettings GetSettings()
        {
            var loggingSettingsFile = _configuration["CoreSettings:Logging:ConfigFile"];
            var loggerTypeConfig = _configuration["CoreSettings:Logging:LoggerType"];

            if(string.IsNullOrEmpty(loggingSettingsFile))
            {
                loggingSettingsFile = "nlog.config";
            }

            ECoreLogging.LoggerType loggerType = ECoreLogging.LoggerType.None;
            if(string.IsNullOrEmpty(loggerTypeConfig) || false == Enum.TryParse(loggerTypeConfig, out loggerType))
            {
                loggerType = ECoreLogging.LoggerType.NLog;
            }


            var settings = new LoggingSettings();
            settings.FileName = loggingSettingsFile;
            settings.LoggerType = loggerType;

            return settings;
            
        }
    }
}