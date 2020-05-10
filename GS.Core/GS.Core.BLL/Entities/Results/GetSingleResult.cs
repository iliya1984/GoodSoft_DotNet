using GS.Core.DAL.Entities.Results;
using GS.Core.Entities.Interfaces;

namespace GS.Core.BLL.Entities.Results
{
    public class GetSingleResult<TEntity> : BusinessOperationResult where TEntity: IEntity
    {
        public TEntity Entity { get; set; }

        public GetSingleResult(){}

        public GetSingleResult(DataGetSingleResult<TEntity> result): base(result)
        {
            Entity = result.Entity;
        }
    }
}