using System;
using CoCo.CRM.Domain.Repositories;
using CoCo.CRM.Domain.Entity;

namespace CoCo.CRM.EntityFramework
{
    /// <summary>
    /// 权限
    /// </summary>
    public class ActionTypeRepository : EntityFrameworkRepository<ActionType>, IActionTypeRepository
    {
        public ActionTypeRepository(IRepositoryContext context)
            : base(context)
        { }
    }
}
