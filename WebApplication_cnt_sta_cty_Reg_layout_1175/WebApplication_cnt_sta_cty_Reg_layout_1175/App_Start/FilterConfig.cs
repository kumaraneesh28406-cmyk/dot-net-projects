using System.Web;
using System.Web.Mvc;

namespace WebApplication_cnt_sta_cty_Reg_layout_1175
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
