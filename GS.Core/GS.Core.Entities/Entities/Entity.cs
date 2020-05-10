using System;
using GS.Core.Entities.Interfaces;

namespace GS.Core.Entities.Entities
{
    public abstract class Entity : IEntity
    {
        public string EntityType { get; private set; }

        protected Entity()
        {
            EntityType = ensureTypeValidAndSet();   
        }

        private string ensureTypeValidAndSet()
        {
            var type = GetType();
            var entityType = type.Name;

            if(entityType.Length < 3)
            {
                throw new Exception($"Error: Entity type {entityType} is too short, minimum three charachter required");
            }

            return entityType;
        }
    }
}