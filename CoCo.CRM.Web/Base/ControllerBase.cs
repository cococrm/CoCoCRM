using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CoCo.CRM.Common;

namespace CoCo.CRM.Web
{
    [HandleError]
    public abstract class ControllerBase : Controller
    {
        /// <summary>
        /// json返回正确
        /// </summary>
        /// <returns></returns>
        protected ActionResult OK()
        {
            var Result = new
            {
                status = 0,
            };
            return Content(Common.Json.ToJson(Result));
        }
        /// <summary>
        /// 返回失败消息
        /// </summary>
        /// <param name="status"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        protected ActionResult Fial(string msg = "系统错误！", int status = 1)
        {
            var Result = new
            {
                status = status,
                msg = msg
            };
            return Content(Common.Json.ToJson(Result));
        }
    }
}
