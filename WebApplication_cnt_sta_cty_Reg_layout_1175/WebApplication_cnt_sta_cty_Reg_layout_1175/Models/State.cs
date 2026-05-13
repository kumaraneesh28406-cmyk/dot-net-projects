using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication_cnt_sta_cty_Reg_layout_1175.Models
{
    public class State
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }
    }
}