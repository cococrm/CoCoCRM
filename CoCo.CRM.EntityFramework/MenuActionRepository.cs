using System;
using CoCo.CRM.Domain.Repositories;
using CoCo.CRM.Domain.Entity;

namespace CoCo.CRM.EntityFramework
{
    /// <summary>
    /// 菜单权限
    /// </summary>
    public class MenuActionRepository : EntityFrameworkRepository<MenuAction>, IMenuActionRepository
    {
        public MenuActionRepository(IRepositoryContext context)
            : base(context)
        { }
    }
}
