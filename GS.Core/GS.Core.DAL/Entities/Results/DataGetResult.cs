using System.Collections.Generic;
using GS.Core.Entities.Interfaces;

namespace GS.Core.DAL.Entities.Results
{
    public class DataGetResult<TEntity> : DataOperationResult where TEntity: IEntity
    {
        public List<TEntity> Entities { get; set; }

        public DataGetResult()
        {
            Entities = new List<TEntity>();
        }
    }
}