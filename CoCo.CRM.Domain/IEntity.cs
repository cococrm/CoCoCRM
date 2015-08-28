using System;

namespace CoCo.CRM.Domain
{
    public interface IEntity<TKey>
    {
        /// <summary>
        /// 获取当前领域实体类的全局唯一标识。
        /// </summary>
        TKey ID { get; }
    }
    public interface IEntity : IEntity<Guid>
    { }
}
