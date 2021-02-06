using System.Web;
using System.Web.Optimization;

namespace CoreAdmChamepe
{
    public class BundleConfig
    {
        // Para obter mais informações sobre o agrupamento, visite https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/dataTables").Include(
        "~/Scripts/dataTables/jquery.dataTables.min.js",
         "~/Scripts/dataTables/dataTables.buttons.min.js",
          "~/Scripts/dataTables/buttons.flash.min.js",
           "~/Scripts/dataTables/jszip.min.js",
            "~/Scripts/dataTables/pdfmake.min.js",
             "~/Scripts/dataTables/vfs_fonts.js",
              "~/Scripts/dataTables/buttons.html5.min.js",
               "~/Scripts/dataTables/buttons.print.min.js"
      ));

            // Use a versão em desenvolvimento do Modernizr para desenvolver e aprender. Em seguida, quando estiver
            // pronto para a produção, utilize a ferramenta de build em https://modernizr.com para escolher somente os testes que precisa.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/bundles/dataTables").Include(
                    "~/Scripts/dataTables/jquery.dataTables.min.css",
                     "~/Scripts/dataTables/buttons.dataTables.min.css"));
        }
    }
}
