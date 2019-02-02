using System.Web;
using System.Web.Optimization;

namespace WeatherBot
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                       "~/Scripts/jquery-{version}.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/app/webtoolkit.base64.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                    "~/Scripts/angular.min.js",
                    "~/Scripts/angular-route.min.js",
                    "~/Scripts/angular-resource.min.js",
                    "~/Scripts/app/app.js",
                    "~/Partials/weather/weather.js",
                    "~/Partials/pokedex/pokedex.js",
                    "~/Partials/evolver/evolver.js",
                    "~/Partials/bosses/bosses.js",
                    "~/Partials/checklist/checklist.js",
                    "~/Scripts/app/ui-bootstrap-tpls-2.5.0.min.js"
                ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
        }
    }
}
