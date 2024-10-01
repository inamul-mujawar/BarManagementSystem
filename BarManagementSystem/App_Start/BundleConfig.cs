using System.Web.Optimization;


public class BundleConfig
{
    public static void RegisterBundles(BundleCollection bundles)
    {

        bundles.Add(new StyleBundle("~/bundles/css-vendor-bundle").Include(
                                    "~/Assets/Vendors/bootstrap-4.3.1-dist/css/bootstrap.min.css",
                                    "~/Assets/Vendors/font-awesome-4.7.0/css/font-awesome.min.css",
                                    "~/Assets/CSS/Global.css"
                        ));

        bundles.Add(new StyleBundle("~/bundles/css-bundle").Include(
                                    "~/Assets/CSS/SideBar.css",
                                    "~/Assets/CSS/SnackBar.css"
                                   // "~/Assets/CSS/font-family-poppins.css"
                                ));

        bundles.Add(new ScriptBundle("~/bundles/bs-jq-bundle").Include(
                                    "~/Assets/Vendors/jquery-3.4.1/jquery-3.4.1.js",
                                    "~/Assets/Vendors/bootstrap-4.3.1-dist/js/bootstrap.min.js",
                                    "~/Assets/JS/Global.js"
                        ));

        bundles.Add(new ScriptBundle("~/bundles/datatable-bundle").Include(
                            "~/Assets/Vendors/dataTables.bootstrap4.min/jquery.dataTables.min.js",
                            "~/Assets/Vendors/dataTables.bootstrap4.min/dataTables.bootstrap4.min.js"

                        ));
        //the following creates bundles in debug mode;
        //BundleTable.EnableOptimizations = true;
    }
}
