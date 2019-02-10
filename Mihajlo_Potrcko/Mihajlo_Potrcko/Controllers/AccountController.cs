using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mihajlo_Potrcko.Components;
using Mihajlo_Potrcko.Connection;
using Mihajlo_Potrcko.LayoutViews;
using Mihajlo_Potrcko.Models;

namespace Mihajlo_Potrcko.Controllers
{
    public class AccountController : Controller
    {
        Potrcko db = new Potrcko();

        public ActionResult Login(string message)
        {
        return View(new ViewDataContainer(message ?? "", new MainView()));
        }

        public ActionResult ParseLogin(string Username, string Password)
        {
            if ((db.Nalog.Where(nalog => nalog.Username.Equals(Username)).Count() == 1))
            {
                var Nalogs = db.Nalog.Where(nalog =>
                    nalog.Username.Equals(Username) && nalog.Password.Equals(Password));

                if (Nalogs.Count() == 1)
                {
                    MvcApplication.UserLogIn(Nalogs.First().JMBG, Session["brojSesije"].ToString());
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return RedirectToAction("Login", new { message = "Pogresan password" });
                }
            }
            if (Username == null)
            {
                return RedirectToAction("Login", new { message = "Username polje ne moze biti prazno" });
            }

            return RedirectToAction("Login",new {message = "Username ne postoji"});

        }

        public ActionResult LogOut()
        {
            MvcApplication.Sessions.Where(a => a.Key.Equals(Session["brojSesije"].ToString())).First().Value.JMBG = "";
            return RedirectToAction("Login","Account", new {message = "Uspesno ste se izlogovali"});
        }

        public ActionResult Signup(string message)
        {
            // staviti na false da se ne vidi slika 
            return View(new ViewDataContainer(message ?? " ", new MainView(true)));

        }

        public ActionResult ParseSignup(string JMBG, string Ime, string Prezime, string Telefon, string Email,
            string Username, string Password)
        { 

            string AccountNumber;
            if (db.Korisnik.Where(korisnik => korisnik.JMBG.Equals(JMBG)).Count() > 0)
            {
                return RedirectToAction("Signup", new {message = "Postoji korisnik sa istim JMBG-om"});
            }
            if (db.Korisnik.Where(korisnik => korisnik.E_mail.Equals(Email)).Count() > 0)
            {
                return RedirectToAction("Signup", new { message = "Postoji korisnik sa istim Email-om" });
            }
            if (db.Nalog.Where(nalog => nalog.Username.Equals(Username)).Count() > 0)
            {
                return RedirectToAction("Signup", new {message = "Postoji korisnik sa istim Username-om"});
            }
            do
            {
                AccountNumber = GenerateRandomAccountNumber();
            } while (db.Korisnik.Where(
                         korisnik => korisnik.Broj_RacunaNB.Equals(AccountNumber)).Count() > 0);
            try
            {
                string sql =
                    "INSERT INTO Nasa_banka(Broj_racunaNB,Stanje_racuna,Poslednja_uplata) " +
                    "VALUES(@param1,@param2,@param3)";

                SqlCommand cmd = new SqlCommand(sql, Konekcija.PKonekcija);
                cmd.Parameters.Add("@param1", SqlDbType.VarChar, 20).Value = AccountNumber;
                cmd.Parameters.Add("@param2", SqlDbType.Decimal, 18).Value = 0;
                cmd.Parameters.Add("@param3", SqlDbType.Date).Value = DateTime.Now.Date;
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                RedirectToAction("Signup", new { message = string.Format("Failed to create new Account i  ako vas zanima da citate: {0}", ex.Message.ToString()) });
            }
            try
            {
                string sql =
                    "INSERT INTO Korisnik(JMBG,Ime,Prezime,Telefon,E_mail,FK_Broj_RacunaNB) " +
                    "VALUES(@param1,@param2,@param3,@param4,@param5,@param6)";

                SqlCommand cmd = new SqlCommand(sql, Konekcija.PKonekcija);
                cmd.Parameters.Add("@param1", SqlDbType.VarChar, 13).Value = JMBG;
                cmd.Parameters.Add("@param2", SqlDbType.VarChar, 20).Value = Ime;
                cmd.Parameters.Add("@param3", SqlDbType.VarChar, 30).Value = Prezime;
                cmd.Parameters.Add("@param4", SqlDbType.VarChar, 20).Value = Telefon;
                cmd.Parameters.Add("@param5", SqlDbType.VarChar, 50).Value = Email;
                cmd.Parameters.Add("@param6", SqlDbType.VarChar, 20).Value = AccountNumber;
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                RedirectToAction("Signup",new {message = string.Format("Failed to create new Korisnik i  ako vas zanima da citate: {0}",ex.Message.ToString()) });
            }
            try
            {
                string sql =
                    "INSERT INTO Nalog(Username,Password,FK_JMBG,FK_SlikaID) " +
                    "VALUES(@param1,@param2,@param3,@param4)";
                SqlCommand cmd = new SqlCommand(sql, Konekcija.PKonekcija);
                cmd.Parameters.Add("@param1", SqlDbType.VarChar, 20).Value = Username;
                cmd.Parameters.Add("@param2", SqlDbType.VarChar, 256).Value = Password;
                cmd.Parameters.Add("@param3", SqlDbType.VarChar, 13).Value = JMBG;
                cmd.Parameters.Add("@param4", SqlDbType.Int).Value = 1;
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                return RedirectToAction("Signup",new {message = string.Format("Failed to create new Nalog i ako vas zanima da citate:",ex.Message.ToString())});
            }
            return RedirectToAction("Login", "Account",new {message = "Sada se mozete ulogovati"});
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