using System.Web;
using System.Web.Mvc;

namespace Rent_A_Car_PR_7_2016
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
