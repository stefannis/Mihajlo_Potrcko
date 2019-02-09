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
    public class KorpaController : Controller
    {
        SessionDataContainer sessionDataContainer;
        // GET: Korpa
        public ActionResult Index()
        {
            var korpa = sessionDataContainer.korpa.SadrzajKorpe;
            return View(new ViewDataContainer(korpa, new MainView()));
        }

        public void Add(Artikal artikal, int kolicina)
        {
            
            MvcApplication.Sessions.TryGetValue(Session["brojSesije"].ToString(), out sessionDataContainer);

            if (sessionDataContainer.korpa.SadrzajKorpe.ContainsKey(artikal))
            {
                sessionDataContainer.korpa.SadrzajKorpe.Where(a => a.Key.Equals(artikal)).First().Value
                    .Increment(kolicina);
                return;
            }

            sessionDataContainer.korpa.SadrzajKorpe.Add(artikal, new IncInt(kolicina));

        }

        public void Delete(Artikal artikal)
        {
            MvcApplication.Sessions.TryGetValue(Session["brojSesije"].ToString(), out sessionDataContainer);

            if (sessionDataContainer.korpa.SadrzajKorpe.ContainsKey(artikal))
            {
                sessionDataContainer.korpa.SadrzajKorpe.Remove(artikal);
                return;
            }
        }

        public void Change(Artikal artikal, int kolicina)
        {
            MvcApplication.Sessions.TryGetValue(Session["brojSesije"].ToString(), out sessionDataContainer);

            if (sessionDataContainer.korpa.SadrzajKorpe.ContainsKey(artikal))
            {
                sessionDataContainer.korpa.SadrzajKorpe.Where(a => a.Key.Equals(artikal)).First().Value.Set(kolicina);
                return;
            }
        }
    }
}