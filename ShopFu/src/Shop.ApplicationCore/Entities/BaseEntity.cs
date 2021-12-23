using Fu.Common.Data;

namespace Shop.ApplicationCore.Entities;

public abstract class BaseEntity:IEntity<int>
{
    public virtual int Id { get; protected set; }

    public object[] GetKeys() => new object[] {Id!};
}