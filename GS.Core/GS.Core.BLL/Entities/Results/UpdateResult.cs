using GS.Core.DAL.Entities.Results;
using GS.Core.Entities.Interfaces;

namespace GS.Core.BLL.Entities.Results
{
    public class UpdateResult<TEntity> : BusinessOperationResult where TEntity: IEntity
    {
        public TEntity Entity { get; set; }

        public UpdateResult(){}

        public UpdateResult(DataUpdateResult<TEntity> result): base(result)
        {
            Entity = result.Entity;
        }
    }
}