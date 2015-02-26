using System.Web;
using System.Web.Mvc;

namespace SolTech.Demos.UnitTesting
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
