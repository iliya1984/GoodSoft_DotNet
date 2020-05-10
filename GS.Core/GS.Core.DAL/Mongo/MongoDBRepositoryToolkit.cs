using GS.Logging.Client.Interfaces;
using GS.Core.DAL.Interfaces.Configuration;
using GS.Core.DAL.Interfaces.Mongo;
using MongoDB.Driver;

namespace GS.Core.DAL.Mongo
{
    public class MongoDBRepositoryToolkit
    {
        public IConfigurationManager ConfigurationManager { get; set; }
        public IMongoDBClientFactory MongoClientFactory { get; set;}
        public ILoggingFactory LoggingFactory { get; set;}
    }
}