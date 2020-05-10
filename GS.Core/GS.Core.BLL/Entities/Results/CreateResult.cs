using System.Linq;
using GS.Core.DAL.Entities.Results;
using GS.Core.Entities.Interfaces;

namespace GS.Core.BLL.Entities.Results
{
    public class CreateResult<TEntity>: BusinessOperationResult where TEntity: IEntity
    {
        public TEntity Entity { get; set; }

        public CreateResult(DataCreateResult<TEntity> dataResult)
        {
            initalize(dataResult);
        }

        private void initalize(DataCreateResult<TEntity> dataResult)
        {
            if(dataResult.Exceptions != null && dataResult.Exceptions.Any())
            {
                Exceptions.AddRange(dataResult.Exceptions);
            }
        }
    }
}