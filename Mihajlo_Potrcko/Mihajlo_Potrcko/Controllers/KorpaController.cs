using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using Mihajlo_Potrcko.Components;
using Mihajlo_Potrcko.LayoutViews;
using Mihajlo_Potrcko.Models;

namespace Mihajlo_Potrcko.Controllers
{
    public class KorpaController : Controller
    {
        // GET: Korisnik
        public ActionResult Index()
        {
            return View(new ViewDataContainer(MvcApplication.GetCurrentKorpa(Session["brojSesije"].ToString()),
                new MainView()));
        }

        [RequireRequestValue("key")]
        public ActionResult Edit(int? key)
        {
            var db = new Potrcko();
            if (key == null)
            {
                return HttpNotFound();
            }
            var currentKorpa = MvcApplication.GetCurrentKorpa(Session["brojSesije"].ToString());

            return View(new ViewDataContainer(currentKorpa.SadrzajKorpe.First(sadrzaj => sadrzaj.Key.Equals(key)), new MainView()));
        }

        public ActionResult Edit(KeyValuePair<int,KorpaContainer> ?pair)
        {
            if (pair.HasValue)
            {
                return HttpNotFound();
            }

            MvcApplication.UpdateKorpa(Session["brojSesije"].ToString(), pair.Value.Key,pair.Value.Value);
            return RedirectToAction("Index");
        }
//        // GET: Korisnik/Edit/5
//        public ActionResult Edit(string id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            Korisnik korisnik = db.Korisnik.Find(id);
//            if (korisnik == null)
//            {
//                return HttpNotFound();
//            }
//            ViewBag.FK_Broj_RacunaNB = new SelectList(db.Nasa_banka, "Broj_racunaNB", "Broj_racunaNB", korisnik.Broj_RacunaNB);
//            return View(new ViewDataContainer(korisnik, new AdminView()));
//        }

//        // POST: Korisnik/Edit/5
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Edit([Bind(Include = "JMBG,Ime,Prezime,Telefon,E_mail,Broj_RacunaNB")] Korisnik korisnik)
//        {
//            if (ModelState.IsValid)
//            {
//                db.Entry(korisnik).State = EntityState.Modified;
//                db.SaveChanges();
//                return RedirectToAction("Index");
//            }
//            ViewBag.FK_Broj_RacunaNB = new SelectList(db.Nasa_banka, "Broj_racunaNB", "Broj_racunaNB", korisnik.Broj_RacunaNB);
//            return View(new ViewDataContainer(korisnik, new AdminView()));
//        }

//        // GET: Korisnik/Delete/5
//        public ActionResult Delete(string id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            Korisnik korisnik = db.Korisnik.Find(id);
//            if (korisnik == null)
//            {
//                return HttpNotFound();
//            }
//            return View(new ViewDataContainer(korisnik, new AdminView()));
//        }

//        // POST: Korisnik/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public ActionResult DeleteConfirmed(string id)
//        {
//            Korisnik korisnik = db.Korisnik.Find(id);
//            db.Korisnik.Remove(korisnik);
//            db.SaveChanges();
//            return RedirectToAction("Index");
//        }

//        protected override void Dispose(bool disposing)
//        {
//            if (disposing)
//            {
//                db.Dispose();
//            }
//            base.Dispose(disposing);
//        }
//    }
    }
}