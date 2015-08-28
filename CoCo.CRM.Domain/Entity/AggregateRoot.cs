using System;

namespace CoCo.CRM.Domain.Entity
{
    public abstract class AggregateRoot<TKey> : IAggregateRoot<TKey>
    {

        protected TKey id;

        /// <summary>
        /// 获取当前领域实体类的全局唯一标识。
        /// </summary>
        public TKey ID
        {
            get { return id; }
            set { id = value; }
        }
    }
    public abstract class AggregateRoot : IAggregateRoot
    {

        protected Guid id;

        /// <summary>
        /// 获取当前领域实体类的全局唯一标识。
        /// </summary>
        public Guid ID
        {
            get { return id; }
            set { id = value; }
        }
    }
}
