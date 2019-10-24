using System.Web;
using System.Web.Mvc;

namespace Bimestral_PrimeiroB
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
