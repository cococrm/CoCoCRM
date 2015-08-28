using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using Newtonsoft.Json;
using CoCo.CRM.Application;
using CoCo.CRM.Application.Impl;
using CoCo.CRM.Infrastructure;
using CoCo.CRM.ModelDTO;
using CoCo.CRM.Common;

namespace CoCo.CRM.Web.Controllers
{
    public class HomeController : ControllerBase
    {
        private readonly ISysMenuService _sysMenuService = ServiceLocator.Instance.GetService<ISysMenuService>();

        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 获取主菜单
        /// </summary>
        /// <returns></returns>
        public ActionResult GetParentMenu()
        {
            return Content(Common.Json.ToJson(_sysMenuService.LoadSystemParent().ToList()));
        }

        /// <summary>
        /// 获取子菜单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult GetChildMenu(Guid id)
        {
            return Content(Common.Json.ToJson(_sysMenuService.LoadSystemMenuChilds(id).ToList()));
        }

    }
}
