using System;

namespace CoCo.CRM.ModelDTO
{
    public abstract class BaseDTO<TKey> : IBaseDTO<TKey>
    {
        public TKey ID { get; set; }
    }
    public abstract class BaseDTO : IBaseDTO
    {
        public Guid ID { get; set; }
    }
}
