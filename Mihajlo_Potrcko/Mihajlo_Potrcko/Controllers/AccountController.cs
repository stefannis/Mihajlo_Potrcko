using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mihajlo_Potrcko.Components;
using Mihajlo_Potrcko.LayoutViews;
using Mihajlo_Potrcko.Models;

namespace Mihajlo_Potrcko.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return Redirect("/Login.cshtml");
        }


        public ActionResult Login(string Username, string Password)
        {
            var db = new Potrcko();
            if ((db.Nalog.Where(nalog => nalog.Username.Equals(Username)).Count() ==1))
            {
                var Nalogs = db.Nalog.Where(nalog =>
                    nalog.Username.Equals(Username) && nalog.Password.Equals(Password));
       
                if (Nalogs.Count() == 1)
                {
                    SessionController.UserLogIn(Nalogs.First().JMBG, Session["brojSesije"].ToString());
                    // da se proveri da li pravi problem ViewDataContainer 
                    return Redirect("../Home/Index.cshtml");
                }
                else
                {
                    return View(new ViewDataContainer("Dobar user los password", new MainView()));
                }
            }
            // ovde je false;
            return View(new ViewDataContainer("Ne postoji user", new MainView())); // sa podacima da je los login
        }

        public ActionResult LogOut()
        {
            //LOGIKA KAD SE ODJAVI
            
            return Redirect("/Login.cshtml");
        }
    }
}