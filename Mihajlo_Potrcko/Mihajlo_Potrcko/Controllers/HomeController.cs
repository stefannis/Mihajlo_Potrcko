using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Mvc;
using Mihajlo_Potrcko.Components;
using Mihajlo_Potrcko.Connection;
using Mihajlo_Potrcko.LayoutViews;
using Mihajlo_Potrcko.Lib.Structs;
using Mihajlo_Potrcko.Models;

namespace Mihajlo_Potrcko.Controllers
{
    public class HomeController : MainViewController
    {
        private readonly Potrcko db = new Potrcko();

        public ActionResult Index()
        {
            var listaPartnera = db.Partner.ToList();
            listaPartnera.Sort();
            listaPartnera = listaPartnera.Take(8).ToList();
            
            

          return View(new ViewDataContainer(listaPartnera, new MainView()));


        }

        public ActionResult KategorijaPoslovnica(string kategorija)
        {
            return View();
        }

        

    }
}