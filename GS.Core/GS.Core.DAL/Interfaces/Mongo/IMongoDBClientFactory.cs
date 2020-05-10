using GS.Core.DAL.Entities.Mongo;
using MongoDB.Driver;

namespace GS.Core.DAL.Interfaces.Mongo
{
    public interface IMongoDBClientFactory
    {
         IMongoClient CreateClient(MongoDBSettings settings);
    }
}