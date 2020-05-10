using System.Collections.Generic;
using System.Linq;
using GS.Core.DAL.Entities.Results;
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

        public GetResult(DataGetResult<TEntity> result): base(result)
        {
            if(result.Entities != null && result.Entities.Any())
            {
                Entities.AddRange(result.Entities);
            }
        }
    }
}