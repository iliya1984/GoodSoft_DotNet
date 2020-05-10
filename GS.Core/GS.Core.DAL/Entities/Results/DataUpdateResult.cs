using GS.Core.Entities.Interfaces;

namespace GS.Core.DAL.Entities.Results
{
    public class DataUpdateResult<TEntity> : DataOperationResult where TEntity: IEntity
    {
        public TEntity Entity { get; set; }
    }
}