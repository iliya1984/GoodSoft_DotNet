using System;
using GS.Messaging.Entities.Consumers;
using GS.Messaging.Entities.Environment;
using GS.Messaging.Entities.Producers;
using Microsoft.Extensions.Configuration;
using NLog;

namespace GS.Messaging.Producers.Configuration
{
    public class ProducerConfigurationManager
    {
        private ILogger _logger;
        private IConfiguration _configuration;

        public ProducerConfigurationManager(IConfiguration configuration, LogFactory logFactory)
        {
            _configuration = configuration;
            _logger = logFactory.GetCurrentClassLogger();
        }

        public ProducerSettings GetSettings()
        {
            try
            {
                var settings = new ProducerSettings();

                var serversJson = _configuration.GetSection("Messaging:BrokerServers");
                foreach(var serverJson in serversJson.GetChildren())
                {
                    var brokerServer = new BrokerServer();
                    brokerServer.Host = serverJson.GetValue<string>("Host");
                    brokerServer.Port = serverJson.GetValue<int>("Port");
                    settings.Servers.Add(brokerServer);
                }

                return settings;
            }
            catch(Exception ex)
            {
                _logger.Error(ex);
                return null;
            }
        }
    }
}