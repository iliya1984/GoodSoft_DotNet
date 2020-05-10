using System;
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

        public DataGetResult(IEnumerable<TEntity> entities) : this()
        {
            if(entities != null)
            {
                Entities.AddRange(entities);
            }
        }

        public DataGetResult(Exception exception, bool isHandled = false): base(exception, isHandled)
        {
            Entities = new List<TEntity>();
        }
    }
}