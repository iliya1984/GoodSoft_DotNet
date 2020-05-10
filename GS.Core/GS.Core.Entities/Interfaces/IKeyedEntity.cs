namespace GS.Core.Entities.Interfaces
{
    public interface IKeyedEntity<TKey> : IEntity
    {
         TKey Key { get; }
    }
}