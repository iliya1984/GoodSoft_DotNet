using GS.Core.BLL.Entities.Results;
using GS.Core.DAL.Entities.Results;
using GS.Core.Entities.Interfaces;

namespace GS.Core.BLL.Extensions
{
    public static class ResultExtensions
    {
        public static CreateResult<TEntity> ToBLLResult<TEntity>(this DataCreateResult<TEntity> result) where TEntity: IEntity
        {
            return new CreateResult<TEntity>(result);
        }

        public static UpdateResult<TEntity> ToBLLResult<TEntity>(this DataUpdateResult<TEntity> result) where TEntity: IEntity
        {
            return new UpdateResult<TEntity>(result);
        }

        public static GetResult<TEntity> ToBLLResult<TEntity>(this DataGetResult<TEntity> result) where TEntity: IEntity
        {
            return new GetResult<TEntity>(result);
        }

        public static GetSingleResult<TEntity> ToBLLResult<TEntity>(this DataGetSingleResult<TEntity> result) where TEntity: IEntity
        {
            return new GetSingleResult<TEntity>(result);
        }
    }
}