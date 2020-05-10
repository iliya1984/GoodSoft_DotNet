using GS.Core.DAL.Entities.Enums;

namespace GS.Core.DAL.Interfaces.Entities
{
    public interface IDbSettings
    {
         string ConnectionString { get; }
         DatabaseTechnology DatabaseTechnology { get; }
    }
}