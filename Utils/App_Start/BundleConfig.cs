using System.Web;
using System.Web.Optimization;

namespace Utils
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            #region Scripts
            bundles.Add(new ScriptBundle("~/Shared").Include(
                "~/Scripts/Page scripts/SharedScripts.js",
                "~/Scripts/Page scripts/localScripts.js"));

            #region 3rd party
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/knockout").Include(
                      "~/Scripts/knockout-3.4.1.js"));
            #endregion

            #region meals
            bundles.Add(new ScriptBundle("~/MealsIndex").Include(
                "~/Scripts/Page scripts/Meals/MealsIndex.js",
                "~/Scripts/Page scripts/Meals/MealsPagedTable.js",
                "~/Scripts/Page scripts/Meals/MealView.js"
                ));
            #endregion

            #endregion

            #region Styles
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/font-awesome.min.css"));
            #endregion
        }
    }
}
