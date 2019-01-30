﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Mvc;
using Mihajlo_Potrcko.Connection;
using Mihajlo_Potrcko.Lib.Structs;
using Mihajlo_Potrcko.Models;

namespace Mihajlo_Potrcko.Controllers
{
    public class HomeController : MainViewController
    {
        private readonly Potrcko db = new Potrcko();
        private readonly SqlCommand query = Konekcija.PKonekcija.CreateCommand();

        public ActionResult Index()
        {
            var listaPoslovnica = db.Poslovnica.ToList();
            listaPoslovnica.Sort();
            listaPoslovnica = listaPoslovnica.Take(8).ToList();

            query.CommandText =
                "SELECT Link FROM Slika, Poslovnica, Partner" +
                " WHERE Poslovnica.PartnerID = Partner.PartnerID AND Partner.SlikaID = Slika.SlikaID";


            List<Slika> listaSlika = db.Slika.Where(slika =>
                                                db.Partner.Where(partner =>
                                                    db.Poslovnica.Any(poslovnica =>
                                                        poslovnica.PartnerID == partner.PartnerID))
                                        .Any(part =>
                                            part.SlikaID.Equals(slika.SlikaID))).ToList();



            


          return View(new ViewDataContainer(new Home
            {
                ListaSlika = listaSlika,
                ListaPoslovnica = listaPoslovnica
            }, new MainView()));


        }

        

    }
}