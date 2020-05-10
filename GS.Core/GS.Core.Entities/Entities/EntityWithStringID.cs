using GS.Core.Entities.ErrorHandling.Exceptions;
using GS.Core.Entities.Interfaces;

namespace GS.Core.Entities.Entities
{
    public abstract class EntityWithStringID: Entity, IEntityWithID<string>
    {
        public string Id { get; private set; }

        protected EntityWithStringID(string id)
        {
            if(string.IsNullOrEmpty(id))
            {
                var idType = typeof(string).Name;

                throw new InvalidEntityIDException(EntityType, idType);
            }
        }
    }
}