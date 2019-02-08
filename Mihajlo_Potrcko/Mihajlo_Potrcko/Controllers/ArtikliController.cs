using Mihajlo_Potrcko.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mihajlo_Potrcko.Components;
using Mihajlo_Potrcko.LayoutViews;

namespace Mihajlo_Potrcko.Controllers
{
    public class ArtikliController : Controller
    {
        private readonly Potrcko db = new Potrcko();

        // GET: Artikli
        public ActionResult Index(int artikalID)
        {
            Artikal artikal =(Artikal) db.Artikal.Where(art => art.ArtikalID.Equals(artikalID));

            return View(new ViewDataContainer(artikal, new MainView()));
        }

        public ActionResult ListaArtikala(int poslovnicaID)
        {
            List<Artikal> listaArtikala = db.Artikal.Where(artikal =>
                db.Artikal_U_Poslovnici.Where(aup => aup.PoslovnicaID.Equals(poslovnicaID))
                    .Any(aup => aup.ArtikalID.Equals(artikal.ArtikalID))).ToList();

            //List<Slika> listaSlika;

            
            return View(new ViewDataContainer(listaArtikala, new MainView()));
        }
    }
}