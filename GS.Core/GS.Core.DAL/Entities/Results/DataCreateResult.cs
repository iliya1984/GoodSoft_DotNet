using System;
using GS.Core.Entities.Interfaces;

namespace GS.Core.DAL.Entities.Results
{
    public class DataCreateResult<TEntity>: DataOperationResult where TEntity: IEntity
    {
        public TEntity Entity { get; set; }

        public DataCreateResult(Exception exception, bool isHandled = false) : base(exception, isHandled)
        {

        }
    }
}