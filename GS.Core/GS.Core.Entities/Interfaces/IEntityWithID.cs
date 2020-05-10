namespace GS.Core.Entities.Interfaces
{
    public interface IEntityWithID<TID> : IEntity
    {
         TID Id { get;}
    }
}