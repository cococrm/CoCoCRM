using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using CoCo.CRM.Domain.Repositories;
using CoCo.CRM.Domain.Entity;
using CoCo.CRM.EntityFramework;
using CoCo.CRM.ModelDTO;
using CoCo.CRM.Common;
using CoCo.CRM.Infrastructure;

namespace CoCo.CRM.Application.Impl
{
    /// <summary>
    /// 导航
    /// </summary>
    public class SysMenuService : BaseService<SysMenu, SysMenuDTO>, ISysMenuService
    {
        private readonly ISysMenuRepository _sysMenuRepository;
        private readonly IActionTypeRepository _actionTypeRepository;
        private readonly IMenuActionRepository _menuActionRepository;

        public SysMenuService(
            ISysMenuRepository sysMenuRepository,
            IActionTypeRepository actionTypeRepository,
            IMenuActionRepository menuActionRepository)
            : base(sysMenuRepository)
        {
            this._sysMenuRepository = sysMenuRepository;
            this._actionTypeRepository = actionTypeRepository;
            this._menuActionRepository = menuActionRepository;
        }

        /// <summary>
        /// 加载所有第一节点导航
        /// </summary>
        /// <returns></returns>
        public IEnumerable<TreeNode> LoadSystemParent()
        {
            var _list = _sysMenuRepository.GetAllParent();
            var list = new List<TreeNode>();
            foreach (var entity in _list)
            {
                TreeNode model = new TreeNode();
                model.Id = entity.ID;
                model.Text = entity.MenuName;
                model.IconCls = entity.Icon;
                list.Add(model);
            }
            return list;
        }

        /// <summary>
        /// 加载系统导航
        /// </summary>
        /// <returns></returns>
        public IEnumerable<TreeNode> LoadSystemMenuChilds(Guid parentId)
        {
            IList<TreeNode> tree = new List<TreeNode>();
            IEnumerable<SysMenu> all = _sysMenuRepository.GetAll(o => o.ParentId.Equals(parentId), o => o.SortId, SortOrder.Ascending);
            GetChildTree(all, parentId, tree, new TreeNode(), new List<TreeNode>());
            return tree;
        }
        

        /// <summary>
        /// 查询所有，Tree格式
        /// </summary>
        /// <returns></returns>
        public IEnumerable<SysMenuDTO> GetAllMenuTree()
        {
            IList<SysMenuDTO> list = new List<SysMenuDTO>();
            IEnumerable<SysMenu> all = _sysMenuRepository.GetAll(o => o.SortId, SortOrder.Ascending);
            GetMenuTree(Mapper.Map<IEnumerable<SysMenu>, IEnumerable<SysMenuDTO>>(all), Guid.Empty, list, new SysMenuDTO(), new List<SysMenuDTO>());
            return list;
        }

        /// <summary>
        /// 获取所有根节点
        /// </summary>
        /// <returns></returns>
        public IEnumerable<SysMenuDTO> GetAllParent()
        {
            var list = _sysMenuRepository.GetAllParent();
            return Mapper.Map<IEnumerable<SysMenu>, IEnumerable<SysMenuDTO>>(list);
        }

        /// <summary>
        /// 根据父节点ID获取当前子节点
        /// </summary>
        /// <param name="parentId"></param>
        /// <returns></returns>
        public IEnumerable<SysMenuDTO> GetChilds(Guid parentId)
        {
            var list = _sysMenuRepository.GetChilds(parentId);
            return Mapper.Map<IEnumerable<SysMenu>, IEnumerable<SysMenuDTO>>(list);
        }
        /// <summary>
        /// 导航，更新添加权限
        /// </summary>
        /// <param name="sysMenu"></param>
        /// <param name="actionType"></param>
        public void AddAction(SysMenuDTO sysMenu, IList<ActionTypeDTO> actionTypes)
        {
            if (sysMenu == null)
                throw new ArgumentNullException("导航对象不能为空！");
            if (actionTypes == null)
                throw new ArgumentNullException("操作权限不能为空！");
            var menuAction = _menuActionRepository.GetAll(o => o.SysMenu_ID.Equals(sysMenu.ID));//获取当前导航权限
            var _actionTypes = Mapper.Map<IList<ActionTypeDTO>, IList<ActionType>>(actionTypes);
            if (menuAction.Count() > 0)//判定是否有权限
                _menuActionRepository.Remove(menuAction);
            foreach (var m in _actionTypes)
            {
                var _menuAction = new MenuAction(sysMenu.ID, m.ID);
                _menuActionRepository.Add(_menuAction);
            }
            _menuActionRepository.Context.Commit();
        }

        #region 私有方法
        /// <summary>
        /// 递归所有导航
        /// </summary>
        /// <param name="list"></param>
        /// <param name="parentId"></param>
        /// <param name="tree"></param>
        /// <param name="node"></param>
        /// <param name="children"></param>
        private void GetChildTree(IEnumerable<SysMenu> list, Guid parentId, IList<TreeNode> tree, TreeNode node, IList<TreeNode> children)
        {
            var clist = list.Where(o => o.ParentId.Equals(parentId)).OrderBy(o => o.SortId);//查找子节点
            foreach (var entity in clist)
            {
                TreeNode model = new TreeNode();
                model.Id = entity.ID;
                model.Text = entity.MenuName;
                model.IconCls = entity.Icon;
                if (entity.LinkUrl != null)
                    model.Attributes = new { url = entity.LinkUrl };
                if (entity.ParentId.Equals(parentId))//判断是否为第一节点
                    tree.Add(model);
                children.Add(model);
                node.Children = children;
                if (_sysMenuRepository.ExistsChildren(entity.ID))//判断是否有子节点
                {
                    children = new List<TreeNode>();
                    GetChildTree(list, entity.ID, tree, model, children);
                }
            }
        }
        /// <summary>
        /// 递归
        /// </summary>
        /// <param name="list"></param>
        /// <param name="parentId"></param>
        /// <param name="tree"></param>
        /// <param name="node"></param>
        /// <param name="children"></param>
        private void GetMenuTree(IEnumerable<SysMenuDTO> list, Guid parentId, IList<SysMenuDTO> tree, SysMenuDTO node, IList<SysMenuDTO> children)
        {
            var clist = list.Where(o => o.ParentId.Equals(parentId)).OrderBy(o => o.SortId);//查找子节点
            foreach (var entity in clist)
            {
                if (entity.ParentId.Equals(Guid.Empty))
                    tree.Add(entity);
                else
                {
                    entity.ParentName = list.Single(o => o.ID == entity.ParentId).MenuName;
                    children.Add(entity);
                }
                node.Children = children;
                if (_sysMenuRepository.ExistsChildren(entity.ID))//判断是否有子节点
                {
                    children = new List<SysMenuDTO>();
                    GetMenuTree(list, entity.ID, tree, entity, children);
                }
            }
        }
        #endregion
    }
}
