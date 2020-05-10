using System.Collections.Generic;
using System.Threading.Tasks;
using GS.Core.BLL.Entities.Results;
using GS.Core.Entities.Interfaces;

namespace GS.Core.BLL.Interfaces.Services
{
    public interface IGetByFilterAsyncService<TFilter, TEntity> where TEntity : IEntity
    {
         Task<GetResult<TEntity>> GetByFilterAsync(TFilter filter);
    }
}