
using System.Threading.Tasks;
using GS.Core.DAL.Entities.Results;
using GS.Core.Entities.Interfaces;

namespace GS.Core.DAL.Interfaces.Repositories
{
    public interface ICreateAsyncRepository<TEntity> where TEntity: IEntity
    {
         Task<DataCreateResult<TEntity>> Create(TEntity entity);
    }
}