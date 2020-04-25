using System;
using System.Linq;
using GS.Core.Logging.Interfaces;
using GS.Core.Messaging.Entities.Common;
using GS.Logging.Entities.Settings;
using GS.Logging.Client.Interfaces;
using Microsoft.Extensions.Configuration;

namespace GS.Logging.Client.Clients
{
    public class LoggingConfigurationManager : ILoggingConfigurationManager
    {
        private IConfiguration _configuration;
        private ICoreLogger _logger;
        private readonly static Type LoggableAttributeType;
        
        static LoggingConfigurationManager()
        {
            LoggableAttributeType = typeof(LoggableAttribute);
        }

        public LoggingConfigurationManager(IConfiguration configuration, ICoreLoggerFactory loggerFactory)
        {
            _configuration = configuration;
            _logger = loggerFactory.GetLoggerForType<LoggingConfigurationManager>();
        }


        public LoggingClientSettings GetSettingsForType<T>(bool isAsync = false)
        {
            try
            {
                var settings = new LoggingClientSettings();
                
                setTopics(settings);

                var type = typeof(T);
                setTypeSettings(type, settings);

                settings.IsAsync = isAsync;

                return settings;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                return null;
            }
        }

        private void setTopics(LoggingClientSettings settings)
        {
            var topic = new Topic();
            topic.Name = _configuration["LoggingClient:Topics:ErrorTopic:Name"];

            if (string.IsNullOrEmpty(topic.Name))
            {
                _logger.Warning("Logging Configuration Build Error: Error topic name was not found");
            }

            topic.Id = _configuration["LoggingClient:Topics:ErrorTopic:Id"];

            settings.Topics.ErrorTopic = topic;

            topic = new Topic();
            topic.Name = _configuration["LoggingClient:Topics:WarningTopic:Name"];

            if (string.IsNullOrEmpty(topic.Name))
            {
                _logger.Warning("Logging Configuration Build Error: Warning topic name was not found");
            }

            topic.Id = _configuration["LoggingClient:Topics:WarningTopic:Id"];

            settings.Topics.WarningTopic = topic;

            topic = new Topic();
            topic.Name = _configuration["LoggingClient:Topics:InfoTopic:Name"];

            if (string.IsNullOrEmpty(topic.Name))
            {
                _logger.Warning("Logging Configuration Build Error: Info topic name was not found");
            }

            topic.Id = _configuration["LoggingClient:Topics:InfoTopic:Id"];

            settings.Topics.InfoTopic = topic;
        }
    
        private void setTypeSettings(Type type, LoggingClientSettings settings)
        {
            settings.LoggerName = type.Name;
            settings.LoggerFullName = type.FullName;
            settings.ClassName = type.Name;
            settings.ClassFullName = type.FullName;

            //TODO: Add module by type caching
            
            var attribute = type
                                .GetCustomAttributes(LoggableAttributeType, true)
                                .FirstOrDefault() as LoggableAttribute;
            
            if(attribute == null)
            {
                throw new Exception($"Error: Loggable attribute for type {type.Name} was not found");
            }

            settings.Module = attribute.Module;
            
        }
    }
}