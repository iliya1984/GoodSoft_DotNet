using GS.Core.DAL.Entities.Enums;
using GS.Core.DAL.Interfaces.Entities;

namespace GS.Core.DAL.Entities
{
    public abstract class DBSettings : IDbSettings
    {
        public string ConnectionString { get; private set; }
        public DatabaseTechnology DatabaseTechnology { get; private set; }

        protected DBSettings(string connectionString, DatabaseTechnology technology)
        {
            ConnectionString = connectionString;
            DatabaseTechnology = technology;
        }
    }
}