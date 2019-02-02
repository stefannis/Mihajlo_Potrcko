using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mihajlo_Potrcko.Components;
using Mihajlo_Potrcko.LayoutViews;

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
            if (true)
            {
                // ovde se dodaje JMBG u SESSIONS DICTIONARY

                return Redirect() // na home page
            }
            // ovde je false;
            return View(); // sa podacima da je los login
        }

        public ActionResult LogOut()
        {
            //LOGIKA KAD SE ODJAVI
            
            return Redirect("/Login.cshtml");
        }
    }
}