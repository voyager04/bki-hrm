using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using Framework.Extensions;
using Helper;

namespace QLNhanSu.App_Start
{
    public partial class BundleConfig
    {
        // TODO: Them constant tham chieu cac KEY BUNDLE_CONFIG
        public const string STYLE_FILE = "~/file";

        public static void CssOptimize(params string[] cssFiles)
        {
            var v_file = new StyleBundle(STYLE_FILE + Utilities.CurrentVersionString + ".css");
            foreach (
                var line in
                    File.ReadAllLines(System.Web.Hosting.HostingEnvironment.MapPath("~/App_Data/Minify/file.cssmin"))
                )
            {
                if (line.IsNotNullOrEmpty())
                {
                    v_file.Include(line);
                }
            }
            BundleTable.Bundles.Add(v_file);
        }
    }
}