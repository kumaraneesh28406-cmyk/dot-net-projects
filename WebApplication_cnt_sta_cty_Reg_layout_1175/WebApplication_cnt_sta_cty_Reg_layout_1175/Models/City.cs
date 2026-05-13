using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication_cnt_sta_cty_Reg_layout_1175.Models
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int StateId { get; set; }
        public State State { get; set; }

        internal static object Select(Func<object, SelectListItem> p)
        {
            throw new NotImplementedException();
        }
    }
}