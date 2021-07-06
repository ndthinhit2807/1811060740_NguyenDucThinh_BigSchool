using System.Web;
using System.Web.Mvc;

namespace _1811060740_NguyenDucThinh_BigSchool
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}