
using System.Threading.Tasks;
using GS.Core.BLL.Entities.Results;
using GS.Core.Entities.Interfaces;

namespace GS.Core.BLL.Interfaces.Services
{
    public interface ICreateAsyncService<TEntity> where TEntity: IEntity
    {
         Task<CreateResult<TEntity>> Create(TEntity entity);
    }
}