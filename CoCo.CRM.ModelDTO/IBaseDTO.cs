using System;

namespace CoCo.CRM.ModelDTO
{
    public interface IBaseDTO<TKey>
    {
        TKey ID { get; set; }
    }
    public interface IBaseDTO : IBaseDTO<Guid>
    { }
}
