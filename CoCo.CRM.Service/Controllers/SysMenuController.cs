using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CoCo.CRM.Application;
using CoCo.CRM.Application.Impl;
using CoCo.CRM.Infrastructure;
using CoCo.CRM.ModelDTO;
using CoCo.CRM.Domain.Entity;

namespace CoCo.CRM.Service.Controllers
{
    /// <summary>
    /// 导航
    /// </summary>
    public class SysMenuController : BaseController
    {
        private readonly ISysMenuService _sysMenuService = ServiceLocator.Instance.GetService<ISysMenuService>();

        public IList<TreeNode> GetAll()
        {
            return _sysMenuService.LoadSystemParent().ToList();
        }

        public IList<TreeNode> GetAll(Guid parentId)
        {
            return _sysMenuService.LoadSystemMenuChilds(parentId).ToList();
        }
        
        //public IList<SysMenuDTO> GetSysMenuParent()
        //{
        //    return _sysMenuService.GetAllParent().ToList();
                                                                                             
        //}
        
        
        public SysMenuDTO Get(Guid id)
        {
            return _sysMenuService.GetByKey(id);
        }

        [HttpPost]
        public void Post()
        {
            //IList<SysMenuDTO> list = new List<SysMenuDTO>();
            //SysMenuDTO model = new SysMenuDTO();
            //model.ID = Guid.NewGuid();//new Guid("B412B8C2-8600-493D-86D9-EF0FD7AD6295");
            //model.MenuName = "系统管理";
            //model.MenuCode = "sys_manager";
            //model.IsLock = false;
            //model.SortId = 99;
            //list.Add(model);
            //SysMenuDTO model1 = new SysMenuDTO();
            //model1.ID = Guid.NewGuid();//new Guid("B412B8C2-8600-493D-86D9-EF0FD7AD6295");
            //model1.MenuName = "系统日志";
            //model1.MenuCode = "sys_manager_log";
            //model1.IsLock = false;
            //model1.SortId = 99;
            //model1.ParentId = model.ID;
            //list.Add(model1);
            //foreach (var entity in list)
            //{
            //    _sysMenuService.Add(entity);
            //}
            //_sysMenuService.AddAction(model, actionList);
        }
    }
}
