using System.Web;
using System.Web.Optimization;

namespace CoCo.CRM.Web
{
    public class BundleConfig
    {
        // 有关 Bundling 的详细信息，请访问 http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Css/css").Include(
                    "~/Scripts/easyui/themes/default/easyui.css",
                    "~/Scripts/easyui/themes/icon.css",
                    "~/Scripts/easyui/themes/color.css",
                    "~/Content/common.css"
                ));

            bundles.Add(new ScriptBundle("~/Scripts/easyui").Include(
                        "~/Scripts/easyui/jquery.min.js",
                        "~/Scripts/easyui/jquery.easyui.min.js",
                        "~/Scripts/jquery.util.js",
                        "~/Scripts/util.js"
                        ));
        }
    }
}