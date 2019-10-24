using System.Web;
using System.Web.Mvc;

namespace Exercicio_17_10_19
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
