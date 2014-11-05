using System.Web;
using System.Web.Mvc;
using QLNhanSu.Filters;

namespace QLNhanSu
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new AuthActivityAttribute());
        }
    }
}