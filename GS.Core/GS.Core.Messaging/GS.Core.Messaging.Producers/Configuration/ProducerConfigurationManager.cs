using System;
using GS.Core.Logging.Interfaces;
using GS.Core.Messaging.Entities.Consumers;
using GS.Core.Messaging.Entities.Environment;
using GS.Core.Messaging.Entities.Producers;
using GS.Core.Messaging.Producers.Interfaces;
using Microsoft.Extensions.Configuration;
using NLog;

namespace GS.Core.Messaging.Producers.Configuration
{
    public class ProducerConfigurationManager : IProducerConfigurationManager
    {
        private ICoreLogger _logger;
        private IConfiguration _configuration;

        public ProducerConfigurationManager(IConfiguration configuration, ICoreLoggerFactory loggerFactory)
        {
            _configuration = configuration;
            _logger = loggerFactory.GetLoggerForType<ProducerConfigurationManager>();
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