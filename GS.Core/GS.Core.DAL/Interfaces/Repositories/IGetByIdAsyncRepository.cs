using System.Threading.Tasks;
using GS.Core.DAL.Entities.Results;
using GS.Core.Entities.Interfaces;

namespace GS.Core.DAL.Interfaces.Repositories
{
    public interface IGetByIdAsyncRepository<TEntity> where TEntity: IEntity
    {
        Task<DataGetSingleResult<TEntity>> GetByIdAsync(string id);
    }
}