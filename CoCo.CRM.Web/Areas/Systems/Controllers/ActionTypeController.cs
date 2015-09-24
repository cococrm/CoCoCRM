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
    public class ActionTypeController : ControllerBase
    {
        private readonly IActionTypeService _service = ServiceLocator.Instance.GetService<IActionTypeService>();

        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 获取菜单按钮
        /// </summary>
        /// <param name="menuId"></param>
        /// <returns></returns>
        public ActionResult GetMenuAction(Guid menuId)
        {
            var all = _service.GetAll();
            var menuAction = _service.GetActionByMenu(menuId);
            var result = from p in all
                         select new
                         {
                             ID = p.ID,
                             Name = p.Name,
                             Icon = p.Icon,
                             Action = p.Action,
                             IsSelect = menuAction.Any(o => o.SysMenu_ID.Equals(p.ID))
                         };
            return Content(Common.Json.ToJson(result));
        }

    }
}
