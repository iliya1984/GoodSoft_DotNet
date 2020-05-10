using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using GS.Core.DAL.Entities.Results;
using GS.Core.Entities.Interfaces;

namespace GS.Core.DAL.Interfaces.Repositories
{
    public interface IGetAllAsyncRepository<TEntity> where TEntity: IEntity
    {
        Task<DataGetResult<TEntity>> GetAllAsync();
    }
}