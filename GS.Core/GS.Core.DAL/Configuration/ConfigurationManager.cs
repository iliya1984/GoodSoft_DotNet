using System;
using GS.Core.DAL.Entities.Enums;
using GS.Core.DAL.Entities.Mongo;
using GS.Core.DAL.Interfaces.Configuration;
using GS.Core.DAL.Interfaces.Entities;
using GS.Logging.Client.Interfaces;
using Microsoft.Extensions.Configuration;

namespace GT.DAL.Configuration
{
    internal class ConfigurationManager : IConfigurationManager
    {
        private IConfiguration _configuration;
        private ILoggingClient _logger;

        public ConfigurationManager(IConfiguration configuration, ILoggingFactory loggingFactory)
        {
            _logger = loggingFactory.GetAsyncLoggerByType<ConfigurationManager>();
            _configuration = configuration;
        }

        public IDbSettings GetSettings()
        {
            IDbSettings settings = null;
            try
            {
                var connectionString = _configuration["DBSetting:ConnectionString"];
                var technologyConfig = _configuration["DBSetting:Technology"];

                DatabaseTechnology technology = DatabaseTechnology.None;
                if(false == Enum.TryParse<DatabaseTechnology>(technologyConfig, out technology))
                {
                    throw new Exception($"Repository configuration error, failed to parse database technology type {technologyConfig}");
                }

                switch(technology)
                {
                    case DatabaseTechnology.MongoDB:

                        var mongoDBSettings =  new MongoDBSettings(connectionString);
                        mongoDBSettings.DatabaseName = _configuration["DBSetting:DatabaseName"];
                        settings = mongoDBSettings;

                        break;
                    default:
                    throw new Exception($"Repository configuration error, invalid technology type {technology}");
                }
            }
            catch(Exception ex)
            {
                _logger.Error(ex);
            }

            return settings;
        }
    }
}