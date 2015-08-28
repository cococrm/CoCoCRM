using System;

namespace CoCo.CRM.Domain
{
    /// <summary>
    /// 聚合跟
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    public interface IAggregateRoot<TKey>:IEntity<TKey>
    {
    }
    public interface IAggregateRoot : IAggregateRoot<Guid>, IEntity
    { }
}
