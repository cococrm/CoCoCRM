using System;
using System.Collections.Generic;
using CoCo.CRM.Domain.Entity;

namespace CoCo.CRM.Domain.Repositories
{
    /// <summary>
    /// 系统导航
    /// </summary>
    public interface ISysMenuRepository : IRepository<SysMenu>
    {
        /// <summary>
        /// 获取全部父目录
        /// </summary>
        /// <returns></returns>
        IEnumerable<SysMenu> GetAllParent();
        /// <summary>
        /// 获取子节点目录
        /// </summary>
        /// <param name="parentId"></param>
        /// <returns></returns>
        IEnumerable<SysMenu> GetChilds(Guid parentId);
        /// <summary>
        /// 判断是否有子目录
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        bool ExistsChildren(Guid Id);
    }
}
