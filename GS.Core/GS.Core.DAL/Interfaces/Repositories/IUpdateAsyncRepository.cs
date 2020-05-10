

using System.Threading.Tasks;
using GS.Core.DAL.Entities.Results;
using GS.Core.Entities.Interfaces;

namespace GS.Core.DAL.Interfaces.Repositories
{
    public interface IUpdateAsyncRepository<TEntity> where TEntity: IEntity
    {
        Task<DataUpdateResult<TEntity>> Update(TEntity entity);
    }
}