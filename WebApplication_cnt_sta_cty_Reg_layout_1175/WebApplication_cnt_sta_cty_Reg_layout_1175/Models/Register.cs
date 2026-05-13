using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication_cnt_sta_cty_Reg_layout_1175.Models
{
    public class Register
    {
        public int Id { get; set; }
        [required]
        public string Name { get; set; }
        [required]
        public string Address { get; set; }
        [Emailaddress]
        public string Email { get; set; }
        public string Phonenumber { get; set; }
        public GenderType Gender { get; set; }
        public Boolean IsSubscribe { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }
        [NotMapped]
        public int StateId { get; set; }
        [NotMapped]
        public int CountryId { get; set; }


    }
}