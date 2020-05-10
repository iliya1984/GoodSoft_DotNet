using System;
using System.Linq;
using GS.Core.DAL.Entities.Results;
using GS.Core.Entities.ErrorHandling.Exceptions;
using GS.Core.Entities.Interfaces;

namespace GS.Core.BLL.Entities.Results
{
    public class CreateResult<TEntity>: BusinessOperationResult where TEntity: IEntity
    {
        public TEntity Entity { get; set; }

        public CreateResult(){}

        public CreateResult(DataCreateResult<TEntity> result): base(result)
        {
            Entity = result.Entity;
        }

        public CreateResult(Exception exception, bool isHandled = false) :base(exception, isHandled){ }
    }
}