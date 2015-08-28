using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Net.Http.Formatting;
using CoCo.CRM.Application;

namespace CoCo.CRM.Service
{
    // 注意: 有关启用 IIS6 或 IIS7 经典模式的说明，
    // 请访问 http://go.microsoft.com/?LinkId=9394801

    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {

            CoCo.CRM.EntityFramework.CoCoCRMDBContextInitailizer.Initialize();

            ApplicationService.Initialize();//加载AutoMapper

            AreaRegistration.RegisterAllAreas();

            GlobalConfiguration.Configuration.Formatters.JsonFormatter.MediaTypeMappings.Add(new QueryStringMapping("json", "true", "application/json"));
            
            GlobalConfiguration.Configuration.MessageHandlers.Add(new CorsHandler());

            WebApiConfig.Register(GlobalConfiguration.Configuration);

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);

            GlobalConfiguration.Configuration.Formatters.XmlFormatter.SupportedMediaTypes.Clear(); 
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            Exception exp = Server.GetLastError();
            CoCo.CRM.Common.Log.Error(exp);//记录全局Error日志
        }
    }
}