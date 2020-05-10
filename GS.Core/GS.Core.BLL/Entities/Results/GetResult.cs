using System.Collections.Generic;
using GS.Core.Entities.Interfaces;

namespace  GS.Core.BLL.Entities.Results
{
    public class GetResult<TEntity> : BusinessOperationResult where TEntity: IEntity
    {
        public List<TEntity> Entities { get; set; }

        public GetResult()
        {
            Entities = new List<TEntity>();
        }
    }
}