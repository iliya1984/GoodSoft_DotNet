using System.Threading.Tasks;
using GS.Core.BLL.Entities.Results;
using GS.Core.Entities.Interfaces;

namespace GS.Core.BLL.Interfaces.Services
{
    public interface IGetByIdAsyncService<TEntity> where TEntity: IEntity
    {
        Task<GetSingleResult<TEntity>> GetByIdAsync(string id);
    }
}