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
        public const string SCRIPT_FILE = "~/file";

        public static bool UseBundles
        {
            get
            {
                try
                {
                    return ConfigurationUtility.GetConfigurationSettingValue("BuiltMode")
                        .Equals("release", StringComparison.OrdinalIgnoreCase);
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }


        public static void JsOptimize(params string[] jsFiles)
        {
            // Admin
            var v_file = new StyleBundle(SCRIPT_FILE + Utilities.CurrentVersionString + ".js");
            foreach (var line in File.ReadAllLines(System.Web.Hosting.HostingEnvironment.MapPath("~/App_Data/Minify/file.jsmin")))
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