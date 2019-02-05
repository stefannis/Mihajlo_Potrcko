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
            return Login();
        }

        public ActionResult Login()
        {
            return View(new ViewDataContainer(null, new MainView()));
        }

        public ActionResult Login(string Username, string Password)
        {
            var db = new Potrcko();
            if ((db.Nalog.Where(nalog => nalog.Username.Equals(Username)).Count() == 1))
            {
                var Nalogs = db.Nalog.Where(nalog =>
                    nalog.Username.Equals(Username) && nalog.Password.Equals(Password));

                if (Nalogs.Count() == 1)
                {
                    MvcApplication.UserLogIn(Nalogs.First().JMBG, Session["brojSesije"].ToString());
                    return new HomeController().Index();
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
            return Login();
        }


        public ActionResult Signup()
        {
            return View(new ViewDataContainer("",new MainView()));

        }

        // resenje za sliku i broj racuna nase banke?
        public ActionResult Signup(string JMBG, string Ime, string Prezime, string Telefon, string Email, string Username, string Password)
        {
            var db = new Potrcko();
            string AccountNumber;
            if (db.Korisnik.Where(korisnik => korisnik.JMBG.Equals(JMBG)).Count() > 0)
            {
                return View(new ViewDataContainer("Postoji korisnik sa istim JMBG-om", new MainView()));
            }
            if (db.Korisnik.Where(korisnik => korisnik.E_mail.Equals(Email)).Count() > 0)
            {
                return View(new ViewDataContainer("Postoji korisnik sa istim Email-om", new MainView()));
            }

            if (db.Nalog.Where(nalog => nalog.Username.Equals(Username)).Count() > 0)
            {
                return View(new ViewDataContainer("Postoji korisnik sa istim Username-om", new MainView()));
            }
            // OVDE IDE QUERRY ZA INSERT U BAZU
            do
            {
                AccountNumber = GenerateRandomAccountNumber();

            } while (db.Korisnik.Where(
                         korisnik => korisnik.Broj_RacunaNB.Equals(AccountNumber)).Count() > 0);

            return new HomeController().Index();
        }



        public string GenerateRandomAccountNumber()
        {
            return string.Format("{0}-{1}{2}-{3}",
                new Random().Next(100, 999),
                new Random().Next(1000000, 9999999),
                new Random().Next(100000, 9999990),
                new Random().Next(10, 99)
            );
        }
    }
}