using GS.Core.DAL.Interfaces.Entities;

namespace GS.Core.DAL.Interfaces.Repositories
{
    public interface IRepository
    {
         IDbSettings Settings { get; }
    }
}