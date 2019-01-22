using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Mihajlo_Potrcko.Connection;
using Mihajlo_Potrcko.Models;

namespace Mihajlo_Potrcko.Controllers
{
    public class HomeController : MainViewController
    {
        private Potrcko db = new Potrcko();

        public ActionResult Index()
        {
            var listaPoslovnica = db.Poslovnica.ToList();
            listaPoslovnica.Sort();
            
            return base.View(new MainView<Home>(new Home()
            {
                ListaPoslovnica = listaPoslovnica.Take(8)
            },"GlavniPogled"));
        }
    }
}