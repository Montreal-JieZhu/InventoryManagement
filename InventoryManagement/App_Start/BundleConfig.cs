using System.Web;
using System.Web.Optimization;

namespace InventoryManagement
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
            //Below are our own style and script files
            bundles.Add(new StyleBundle("~/MyLayoutStyle/css").Include(
                "~/assets/vendor/bootstrap/css/bootstrap.min.css",
                      "~/assets/vendor/font-awesome/css/font-awesome.min.css",                     
                      "~/assets/vendor/chartist/css/chartist-custom.css",
                      "~/assets/css/*.css",
                       "~/assets/vendor/linearicons/style.css"
                      ));

            bundles.Add(new ScriptBundle("~/MyLayoutScript/js").Include(
                "~/assets/vendor/jquery/jquery.min.js",
                "~/assets/vendor/bootstrap/js/bootstrap.min.js",
                      "~/assets/vendor/jquery-slimscroll/jquery.slimscroll.min.js",
                      "~/assets/vendor/jquery.easy-pie-chart/jquery.easypiechart.min.js",
                      "~/assets/vendor/chartist/js/chartist.min.js",
                      "~/assets/scripts/klorofil-common.js"));
        }
    }
}
