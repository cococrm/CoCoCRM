using System.Data.Entity;
using CoCo.CRM.Domain.Repositories;
using CoCo.CRM.Infrastructure;

namespace CoCo.CRM.EntityFramework
{
    public interface IEntityFrameworkRepositoryContext : IRepositoryContext
    {
        /// <summary>
        /// 获取当前仓储上下文所使用的Entity Framework的实例。
        /// </summary>
        DbContext Context { get; }
    }
}
