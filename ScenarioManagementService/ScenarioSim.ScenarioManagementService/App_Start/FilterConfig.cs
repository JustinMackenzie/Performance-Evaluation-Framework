using System.Web;
using System.Web.Mvc;

namespace ScenarioSim.ScenarioManagementService
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
