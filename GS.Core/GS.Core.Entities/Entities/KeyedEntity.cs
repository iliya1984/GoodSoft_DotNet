using GS.Core.Entities.Interfaces;

namespace GS.Core.Entities.Entities
{
    public class KeyedEntity<TKey> : Entity, IKeyedEntity<TKey>
    {
        public TKey Key { get; }
    }
}