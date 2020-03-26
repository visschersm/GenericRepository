namespace DataLayer.Entities.Interfaces
{
    public interface IEntity
    {
        object Id { get; }
    }

    public interface IEntity<TKey> : IEntity
    {
        new TKey Id { get; set; }
    }
}
