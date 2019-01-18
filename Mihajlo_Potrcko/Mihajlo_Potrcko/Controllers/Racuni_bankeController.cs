using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Mihajlo_Potrcko.Models;
using EntityState = System.Data.Entity.EntityState;

namespace Mihajlo_Potrcko.Controllers
{
    public class Racuni_bankeController : Controller
    {
        private PotrckoDB db = new PotrckoDB();

        // GET: Racuni_banke
        public ActionResult Index()
        {
            var racuni_banke = db.RacuniBanke.Include(r => r.Korisnik);
            return View(racuni_banke.ToList());
        }

        // GET: Racuni_banke/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Racuni_banke racuni_banke = db.RacuniBanke.Find(id);
            if (racuni_banke == null)
            {
                return HttpNotFound();
            }
            return View(racuni_banke);
        }

        // GET: Racuni_banke/Create
        public ActionResult Create()
        {
            ViewBag.FK_JMBG = new SelectList(db.Korisnik, "JMBG", "Ime");
            return View();
        }

        // POST: Racuni_banke/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Broj_racuna,Naziv_banke,Vlasnik_racuna,Datum_isteka,FK_JMBG")] Racuni_banke racuni_banke)
        {
            if (ModelState.IsValid)
            {
                db.RacuniBanke.Add(racuni_banke);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FK_JMBG = new SelectList(db.Korisnik, "JMBG", "Ime", racuni_banke.FK_JMBG);
            return View(racuni_banke);
        }

        // GET: Racuni_banke/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Racuni_banke racuni_banke = db.RacuniBanke.Find(id);
            if (racuni_banke == null)
            {
                return HttpNotFound();
            }
            ViewBag.FK_JMBG = new SelectList(db.Korisnik, "JMBG", "Ime", racuni_banke.FK_JMBG);
            return View(racuni_banke);
        }

        // POST: Racuni_banke/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Broj_racuna,Naziv_banke,Vlasnik_racuna,Datum_isteka,FK_JMBG")] Racuni_banke racuni_banke)
        {
            if (ModelState.IsValid)
            {
                db.Entry(racuni_banke).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FK_JMBG = new SelectList(db.Korisnik, "JMBG", "Ime", racuni_banke.FK_JMBG);
            return View(racuni_banke);
        }

        // GET: Racuni_banke/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Racuni_banke racuni_banke = db.RacuniBanke.Find(id);
            if (racuni_banke == null)
            {
                return HttpNotFound();
            }
            return View(racuni_banke);
        }

        // POST: Racuni_banke/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Racuni_banke racuni_banke = db.RacuniBanke.Find(id);
            db.RacuniBanke.Remove(racuni_banke);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
