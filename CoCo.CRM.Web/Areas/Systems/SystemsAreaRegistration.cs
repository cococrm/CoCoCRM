using System.Web.Mvc;

namespace CoCo.CRM.Web.Areas.Systems
{
    /// <summary>
    /// 系统模块
    /// </summary>
    public class SystemsAreaRegistration : AreaRegistration
    {
        /// <summary>
        /// 区域名称
        /// </summary>
        public override string AreaName
        {
            get { return "Systems"; }
        }
        /// <summary>
        /// 注册路由
        /// </summary>
        /// <param name="context"></param>
        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Systems_default",
                "Systems/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}