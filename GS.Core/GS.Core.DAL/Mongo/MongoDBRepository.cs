using MongoDB.Driver;
using System.Collections.Generic;
using GS.Core.DAL.Entities.Mongo;
using GS.Core.DAL.Repositories;

namespace GS.Core.DAL.Mongo
{
    public abstract class MongoDBRepository<DBEntity>: Repository
    {
       
        protected IMongoClient Client { get; private set; } 
        protected IMongoDatabase Database { get; private set; }
        protected IMongoCollection<DBEntity> Collection { get; set; }

        protected MongoDBRepository(MongoDBRepositoryToolkit toolkit, string collectionName)
            : base(toolkit.ConfigurationManager, toolkit.LoggingFactory)
        {
            var mongoDbSettings = (MongoDBSettings)Settings;

            Client = toolkit.MongoClientFactory.CreateClient(mongoDbSettings);
            Database = Client.GetDatabase(mongoDbSettings.DatabaseName);
            Collection = Database.GetCollection<DBEntity>(collectionName); 
        }

        protected List<TEntity> EmptyResult<TEntity>()
        {
            return new List<TEntity>();
        }
    }
}