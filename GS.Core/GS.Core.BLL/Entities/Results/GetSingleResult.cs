using GS.Core.Entities.Interfaces;

namespace GS.Core.BLL.Entities.Results
{
    public class GetSingleResult<TEntity> : BusinessOperationResult where TEntity: IEntity
    {
        public TEntity Entity { get; set; }
    }
}