using DataLayer.Entities.Interfaces;

namespace DataLayer.Entities
{
    public abstract class BaseEntity<TKey> : IEntity<TKey>
    {
        public TKey Id { get; set; } = default!;

        object IEntity.Id => Id!;
    }
}
