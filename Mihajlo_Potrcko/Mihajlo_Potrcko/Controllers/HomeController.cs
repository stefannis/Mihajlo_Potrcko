using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
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
            var listaPoslovnica = db.Poslovnica.ToList(); //DB querry
            listaPoslovnica.Sort(); // abuse data
            listaPoslovnica = listaPoslovnica.Take(8).ToList(); // abusedata some more

            query.CommandText =
                "SELECT Link FROM Slika, Poslovnica, Partner" +
                " WHERE Poslovnica.FK_PartnerID = Partner.PartnerID AND Partner.FK_SlikaID = Slika.SlikaID";


            List<Slika> listaSlika = db.Slika.Where(slika =>
                db.Partner.Where(partner =>
                        db.Poslovnica.Any(poslovnica =>
                            poslovnica.FK_PartnerID == partner.PartnerID))
                    .Any(part =>
                        part.FK_SlikaID.Equals(slika.SlikaID))).ToList();

            int? atr1 = null;
            Home atr2 = null;
            object atr3 = null;

            Metoda1(atr1,atr2);

            Metoda1(atr1, atr2, atr3);

            Metoda1(null,null,null);
            

            listaSlika.ForEach((Slika slika) => { Console.WriteLine(slika.SlikaID); });



        return View(new ViewDataContainer(new Home
            {
                ListaSlika = listaSlika,
                ListaPoslovnica = listaPoslovnica // use data
            }, new MainView())); // return to view


        }

        private void Metoda1(int? atr1, object atr2)
        {
            throw new NotImplementedException();
        }

        private void Metoda1(int? KojiSeKoristiZa, Home KojiSeKoristiZaNestoDrugo)
        {
            if (KojiSeKoristiZa == null)
            {
                throw new ArgumentNullException(nameof(KojiSeKoristiZa));
            }

            throw new NotImplementedException();
        }
        private void Metoda1(int? atr1, Home atr12, object atr3)
        {
            throw new NotImplementedException();
        }
    }
}