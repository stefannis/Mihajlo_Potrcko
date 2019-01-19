using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Mihajlo_Potrcko.Models;

namespace Mihajlo_Potrcko.Controllers
{
    public class HomeController : MainViewController
    {

        private Potrcko db = new Potrcko();

        // GET: Home
        //public ActionResult Index()
        //{
        //    var listaPartnera = db.Partner.ToList();
        //    listaPartnera.Sort();
        //    return base.View(listaPartnera.Take(8));
        //}

    }
}