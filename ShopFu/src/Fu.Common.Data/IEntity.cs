namespace Fu.Common.Data;

public interface IEntity
{
    object[] GetKeys();
}

public interface IEntity<TKey> : IEntity
{
    /// <summary>
    /// Unique identifier for this entity.
    /// </summary>
    TKey Id { get; }
}