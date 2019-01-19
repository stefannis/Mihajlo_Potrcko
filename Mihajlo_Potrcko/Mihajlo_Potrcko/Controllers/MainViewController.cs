using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mihajlo_Potrcko.Models;

namespace Mihajlo_Potrcko.Controllers
{
    public class MainViewController : Controller
    {
        private Potrcko db = new Potrcko();
        // GET: MainView

        public ActionResult Index()
        {
            var listaPartnera = db.Partner.ToList();
            listaPartnera.Sort();
            ViewBag.Partneri = listaPartnera.Take(8);
            return this.View(new Home() { Name = "Ovojedrugavrednost" });
        }
    }
}