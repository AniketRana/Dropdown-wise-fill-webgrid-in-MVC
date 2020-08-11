using System.Web;
using System.Web.Mvc;

namespace DropDown_wise_fill_GridData
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
