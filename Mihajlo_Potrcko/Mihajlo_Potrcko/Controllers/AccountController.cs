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
                    MvcApplication.UserLogIn(Nalogs.First().JMBG, Session["brojSesije"].ToString());
                    return Redirect("~/");
                }
                else
                {
                    return View(new ViewDataContainer("Dobar user los password", new MainView()));
                }
            }
            // ovde je false;
            if (Username == null)
            {
                return View(new ViewDataContainer("", new MainView())); // inicijalna konstrukcija
            }
            return View(new ViewDataContainer("Ne postoji user", new MainView())); // sa podacima da je los login
        }

        public ActionResult LogOut()
        {
            //LOGIKA KAD SE ODJAVI

            MvcApplication.Sessions.Where(a => a.Key.Equals(Session["brojSesije"].ToString())).First().Value.JMBG = "";
            return Redirect("/Login.cshtml");
        }

        // resenje za sliku i broj racuna nase banke?
        public ActionResult Signup(string JMBG, string Ime, string Prezime, string Telefon, string Email, string Username, string Password)
        {
            return null;
        }
    }
}