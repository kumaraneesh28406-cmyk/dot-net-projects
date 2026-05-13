using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using WebApplication_cnt_sta_cty_Reg_layout_1175.Data;
using WebApplication_cnt_sta_cty_Reg_layout_1175.Models;

namespace WebApplication_cnt_sta_cty_Reg_layout_1175.Controllers
{
    public class RegisterController : Controller
    {
        private readonly ApplicationDbContext context;
        public RegisterController()
        {
            context = new ApplicationDbContext();
        }
        // GET: Register
        public ActionResult Index()
        {
            var userlist = context.Registers.Include(r => r.City).Include(r => r.City.State).Include(r => r.City.State.Country).ToList();
            return View(userlist);
        }
      
        public ActionResult Upsert(int? Id)
        {
            ViewBag.Countrylist = context.Countries.ToList();
            ViewBag.Statelist = context.States.ToList();
            ViewBag.Citylist =  context.Cities.ToList();


            //create
            Register register = new Register();
            if (Id == null) return View(register);

            //edit
            register = context.Registers.Find(Id.GetValueOrDefault());
            if (register == null) return HttpNotFound();
            register.StateId = register.City.State.Id;
            register.CountryId = register.City.State.Country.Id;
            return View(register);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Upsert(Register register)
        {
            if (register == null) return HttpNotFound();
            //if (!ModelState.IsValid) return View(register);
            if (!ModelState.IsValid)
            {
                ViewBag.Countrylist = context.Countries.ToList();
                ViewBag.Statelist = context.States.ToList();
                ViewBag.Citylist = context.Cities.ToList();

                return View(register);
            }

            if (register.Id == 0)

                context.Registers.Add(register); //SAVE
            else
            //update
            {
                var UserInDb = context.Registers.Find(register.Id);
                if (UserInDb == null) return HttpNotFound();
                UserInDb.Name = register.Name;
                UserInDb.Address = register.Name;
                UserInDb.Email = register.Email;
                UserInDb.Phonenumber = register.Phonenumber;
                UserInDb.IsSubscribe = register.IsSubscribe;
                UserInDb.CityId = register.CityId;
                //UserInDb.StateId = register.StateId;

            }

            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public ActionResult Details(int id)
        {
            var userFromDb = context.Registers.Include(r => r.City).Include(r => r.City.State).Include(r => r.City.State.Country).FirstOrDefault(r => r.Id == id);
            if (userFromDb == null) return HttpNotFound();
            return View(userFromDb);
        }
        public ActionResult Delete(int id)
        {
            var UserInDb = context.Registers.Find(id);
            if (UserInDb == null) return HttpNotFound();
            context.Registers.Remove(UserInDb);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        #region     APIS
        private List<State> GetStates(int CountryId)
        {
            return context.States.Where(s => s.CountryId == CountryId).ToList();
        }
        private List<City>GetCity(int StateId)
        {
            return context.Cities.Where(c => c.StateId == StateId).ToList();
        }
        public ActionResult loadStateByCountryId(int CountryId)
        {
            var States = GetStates(CountryId);
            var StateListData = States.Select(Sl => new SelectListItem()
            {
                Text = Sl.Name,
                Value = Sl.Id.ToString()
            });
            return Json(StateListData, JsonRequestBehavior.AllowGet);
        }
        public ActionResult localcityByStateId(int StateId)
        {
            var City = GetCity(StateId);
            var CityListData = City.Select(Cl => new SelectListItem()
            {
                Text = Cl.Name,
                Value = Cl.Id.ToString()
            });
            return Json(CityListData, JsonRequestBehavior.AllowGet);
        }

        #endregion

    }
}
    
