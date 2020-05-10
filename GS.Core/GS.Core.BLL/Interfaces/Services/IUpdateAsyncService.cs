

using System.Threading.Tasks;
using GS.Core.BLL.Entities.Results;
using GS.Core.Entities.Interfaces;

namespace GS.Core.BLL.Interfaces.Services
{
    public interface IUpdateAsyncService<TEntity> where TEntity: IEntity
    {
        Task<UpdateResult<TEntity>> Update(TEntity entity);
    }
}