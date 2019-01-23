﻿using System;
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
            List<Partner> listaPartnera = db.Partner.ToList();
            listaPartnera.Sort();
            
            return base.View(new ViewDataContainer(new Home()
            {
                ListaPartnera = listaPartnera.Take(8)
            },new MainView()));
        }
    }
}