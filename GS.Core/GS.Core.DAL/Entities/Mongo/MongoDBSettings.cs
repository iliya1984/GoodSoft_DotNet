using GS.Core.DAL.Entities.Enums;

namespace GS.Core.DAL.Entities.Mongo
{
    public class MongoDBSettings : DBSettings
    {
        public MongoDBSettings(string connectionString) : base(connectionString, DatabaseTechnology.MongoDB)
        {
        }

        public string DatabaseName { get; set;}
    }
}