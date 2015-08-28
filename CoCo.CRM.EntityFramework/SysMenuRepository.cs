using System;
using System.Linq;
using System.Collections.Generic;
using CoCo.CRM.Domain.Repositories;
using CoCo.CRM.Domain.Entity;
using CoCo.CRM.Infrastructure;

namespace CoCo.CRM.EntityFramework
{
    /// <summary>
    /// 系统导航
    /// </summary>
    public class SysMenuRepository : EntityFrameworkRepository<SysMenu>, ISysMenuRepository
    {
        public SysMenuRepository(IRepositoryContext context)
            : base(context)
        { 
            
        }
        /// <summary>
        /// 获取所以父目录
        /// </summary>
        /// <returns></returns>
        public IEnumerable<SysMenu> GetAllParent()
        {
            return GetAll(o => o.ParentId.Equals(Guid.Empty), o => o.SortId, SortOrder.Ascending);
        }
        /// <summary>
        /// 获取子目录
        /// </summary>
        /// <param name="parentId"></param>
        /// <returns></returns>
        public IEnumerable<SysMenu> GetChilds(Guid parentId)
        {
            return GetAll(o => o.ParentId.Equals(parentId), o => o.SortId, SortOrder.Ascending);
        }
        /// <summary>
        /// 判断是否存在子目录
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public bool ExistsChildren(Guid Id)
        {
            var list = GetAll(o => o.ParentId.Equals(Id));
            if (list.Count() > 0)
                return true;
            return false;
        }
    }
}
