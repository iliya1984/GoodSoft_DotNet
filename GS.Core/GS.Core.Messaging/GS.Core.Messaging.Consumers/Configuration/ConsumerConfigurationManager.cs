using System;
using GS.Core.Logging.Interfaces;
using GS.Core.Messaging.Consumers.Interfaces;
using GS.Core.Messaging.Entities.Consumers;
using GS.Core.Messaging.Entities.Environment;
using Microsoft.Extensions.Configuration;
using NLog;

namespace GS.Core.Messaging.Consumers.Configuration
{
    public class ConsumerConfigurationManager : IConsumerConfigurationManager
    {
        private ICoreLogger _logger;
        private IConfiguration _configuration;

        public ConsumerConfigurationManager(IConfiguration configuration, ICoreLoggerFactory logFactory)
        {
            _configuration = configuration;
            _logger = logFactory.GetLoggerForType<ConsumerConfigurationManager>();
        }

        public ConsumerSettings GetSettings()
        {
            try
            {
                var consumerSettings = new ConsumerSettings();

                var serversJson = _configuration.GetSection("Messaging:BrokerServers");
                foreach(var serverJson in serversJson.GetChildren())
                {
                    var brokerServer = new BrokerServer();
                    brokerServer.Host = serverJson.GetValue<string>("Host");
                    brokerServer.Port = serverJson.GetValue<int>("Port");
                    consumerSettings.Servers.Add(brokerServer);
                }

                consumerSettings.Group = _configuration.GetValue<string>("Messaging:Group");
                return consumerSettings;
            }
            catch(Exception ex)
            {
                _logger.Error(ex);
                return null;
            }
        }
    }
}