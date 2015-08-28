using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using CoCo.CRM.Application;
using CoCo.CRM.Application.Impl;
using CoCo.CRM.Infrastructure;
using CoCo.CRM.ModelDTO;
using CoCo.CRM.Common;

namespace CoCo.CRM.Web.Areas.Systems.Controllers
{
    /// <summary>
    /// 导航菜单
    /// </summary>
    public class NavigationController : ControllerBase
    {
        private readonly ISysMenuService _sysMenuService = ServiceLocator.Instance.GetService<ISysMenuService>();
        
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 获取所有导航
        /// </summary>
        /// <returns></returns>
        public ActionResult Query()
        {
            //return Json(_sysMenuService.GetAllMenuTree(),JsonRequestBehavior.AllowGet);
            return Content(Common.Json.ToJson(_sysMenuService.GetAllMenuTree()));
        }

    }
}
