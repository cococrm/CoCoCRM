using System;
using System.Collections;
using System.Collections.Generic;
using CoCo.CRM.Domain.Entity;
using CoCo.CRM.ModelDTO;
using CoCo.CRM.Common;

namespace CoCo.CRM.Application
{
    /// <summary>
    /// 系统导航
    /// </summary>
    public interface ISysMenuService : IBaseService<SysMenuDTO>
    {
        /// <summary>
        /// 加载所有第一节点导航
        /// </summary>
        /// <returns></returns>
        IEnumerable<TreeNode> LoadSystemParent();
        /// <summary>
        /// 加载系统子节点导航
        /// </summary>
        /// <returns></returns>
        IEnumerable<TreeNode> LoadSystemMenuChilds(Guid parentId);
        /// <summary>
        /// 查询所有，Tree格式
        /// </summary>
        /// <returns></returns>
        IEnumerable<SysMenuDTO> GetAllMenuTree();
        /// <summary>
        /// 获取父目录
        /// </summary>
        /// <returns></returns>
        IEnumerable<SysMenuDTO> GetAllParent();
        /// <summary>
        /// 获取子目录
        /// </summary>
        /// <param name="parentId"></param>
        /// <returns></returns>
        IEnumerable<SysMenuDTO> GetChilds(Guid parentId);
        /// <summary>
        /// 添加，更新权限菜单
        /// </summary>
        /// <param name="Id">导航ID</param>
        /// <param name="ActionId">权限列表</param>
        void AddAction(SysMenuDTO sysMenu, IList<ActionTypeDTO> actionTypes);
    }
}
