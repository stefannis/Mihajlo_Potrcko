using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Mihajlo_Potrcko.Connection;
using Mihajlo_Potrcko.Models;
using System.Data.SqlClient;

namespace Mihajlo_Potrcko.Controllers
{
    public class HomeController : MainViewController
    {
        private Potrcko db = new Potrcko();
        private SqlCommand query = Konekcija.PKonekcija.CreateCommand();

        public ActionResult Index()
        {

            List<Poslovnica> listaPoslovnica = db.Poslovnica.ToList();
            listaPoslovnica.Sort();
            listaPoslovnica = listaPoslovnica.Take(8).ToList();

            query.CommandText =
                "SELECT Link FROM Slika, Poslovnica, Partner" +
                " WHERE Poslovnica.FK_PartnerID = Partner.PartnerID AND Partner.FK_SlikaID = Slika.SlikaID";
            SqlDataReader reader = query.ExecuteReader();
            List<string> listaSlika = new List<string>();
            while (reader.Read())
            {
                listaSlika.Add(reader.GetString(0));
            }

            return View(new ViewDataContainer(new Home()
            {
                ListaSlika = listaSlika,
                ListaPoslovnica = listaPoslovnica
            }, new MainView()));




        }
    }
}