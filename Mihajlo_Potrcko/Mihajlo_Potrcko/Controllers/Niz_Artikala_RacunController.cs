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
    public class Niz_Artikala_RacunController : Controller
    {
        private PotrckoDB db = new PotrckoDB();

        // GET: Niz_Artikala_Racun
        public ActionResult Index()
        {
            var niz_Artikala_Racun = db.NizArtikalaRacun.Include(n => n.Artikal).Include(n => n.Racun);
            return View(niz_Artikala_Racun.ToList());
        }

        // GET: Niz_Artikala_Racun/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Niz_Artikala_Racun niz_Artikala_Racun = db.NizArtikalaRacun.Find(id);
            if (niz_Artikala_Racun == null)
            {
                return HttpNotFound();
            }
            return View(niz_Artikala_Racun);
        }

        // GET: Niz_Artikala_Racun/Create
        public ActionResult Create()
        {
            ViewBag.FK_ArtikalID = new SelectList(db.Artikal, "ArtikalID", "Naziv_artikla");
            ViewBag.FK_RacunID = new SelectList(db.Racun, "RacunID", "Adresa");
            return View();
        }

        // POST: Niz_Artikala_Racun/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Niz_artikla_racunID,Kolicina,FK_RacunID,FK_ArtikalID")] Niz_Artikala_Racun niz_Artikala_Racun)
        {
            if (ModelState.IsValid)
            {
                db.NizArtikalaRacun.Add(niz_Artikala_Racun);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FK_ArtikalID = new SelectList(db.Artikal, "ArtikalID", "Naziv_artikla", niz_Artikala_Racun.FK_ArtikalID);
            ViewBag.FK_RacunID = new SelectList(db.Racun, "RacunID", "Adresa", niz_Artikala_Racun.FK_RacunID);
            return View(niz_Artikala_Racun);
        }

        // GET: Niz_Artikala_Racun/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Niz_Artikala_Racun niz_Artikala_Racun = db.NizArtikalaRacun.Find(id);
            if (niz_Artikala_Racun == null)
            {
                return HttpNotFound();
            }
            ViewBag.FK_ArtikalID = new SelectList(db.Artikal, "ArtikalID", "Naziv_artikla", niz_Artikala_Racun.FK_ArtikalID);
            ViewBag.FK_RacunID = new SelectList(db.Racun, "RacunID", "Adresa", niz_Artikala_Racun.FK_RacunID);
            return View(niz_Artikala_Racun);
        }

        // POST: Niz_Artikala_Racun/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Niz_artikla_racunID,Kolicina,FK_RacunID,FK_ArtikalID")] Niz_Artikala_Racun niz_Artikala_Racun)
        {
            if (ModelState.IsValid)
            {
                db.Entry(niz_Artikala_Racun).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FK_ArtikalID = new SelectList(db.Artikal, "ArtikalID", "Naziv_artikla", niz_Artikala_Racun.FK_ArtikalID);
            ViewBag.FK_RacunID = new SelectList(db.Racun, "RacunID", "Adresa", niz_Artikala_Racun.FK_RacunID);
            return View(niz_Artikala_Racun);
        }

        // GET: Niz_Artikala_Racun/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Niz_Artikala_Racun niz_Artikala_Racun = db.NizArtikalaRacun.Find(id);
            if (niz_Artikala_Racun == null)
            {
                return HttpNotFound();
            }
            return View(niz_Artikala_Racun);
        }

        // POST: Niz_Artikala_Racun/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Niz_Artikala_Racun niz_Artikala_Racun = db.NizArtikalaRacun.Find(id);
            db.NizArtikalaRacun.Remove(niz_Artikala_Racun);
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
