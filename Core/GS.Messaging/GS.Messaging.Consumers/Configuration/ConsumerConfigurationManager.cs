using System;
using GS.Messaging.Entities.Consumers;
using GS.Messaging.Entities.Environment;
using Microsoft.Extensions.Configuration;
using NLog;

namespace GS.Messaging.Consumers.Configuration
{
    public class ConsumerConfigurationManager
    {
        private ILogger _logger;
        private IConfiguration _configuration;

        public ConsumerConfigurationManager(IConfiguration configuration, LogFactory logFactory)
        {
            _configuration = configuration;
            _logger = logFactory.GetCurrentClassLogger();
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