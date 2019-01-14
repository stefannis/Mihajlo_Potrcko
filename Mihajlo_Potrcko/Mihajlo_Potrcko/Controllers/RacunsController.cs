using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Mihajlo_Potrcko.Models;

namespace Mihajlo_Potrcko.Controllers
{
    public class RacunsController : Controller
    {
        private Potrcko db = new Potrcko();

        // GET: Racuns
        public ActionResult Index()
        {
            var racun = db.Racun.Include(r => r.Kupac).Include(r => r.Vozac);
            return View(racun.ToList());
        }

        // GET: Racuns/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Racun racun = db.Racun.Find(id);
            if (racun == null)
            {
                return HttpNotFound();
            }
            return View(racun);
        }

        // GET: Racuns/Create
        public ActionResult Create()
        {
            ViewBag.FK_KupacID = new SelectList(db.Kupac, "KupacID", "FK_JMBG");
            ViewBag.FK_VozacID = new SelectList(db.Vozac, "VozacID", "FK_JMBG");
            return View();
        }

        // POST: Racuns/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RacunID,Datum_izdavanja,Iznos,FK_KupacID,FK_VozacID,Adresa")] Racun racun)
        {
            if (ModelState.IsValid)
            {
                db.Racun.Add(racun);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FK_KupacID = new SelectList(db.Kupac, "KupacID", "FK_JMBG", racun.FK_KupacID);
            ViewBag.FK_VozacID = new SelectList(db.Vozac, "VozacID", "FK_JMBG", racun.FK_VozacID);
            return View(racun);
        }

        // GET: Racuns/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Racun racun = db.Racun.Find(id);
            if (racun == null)
            {
                return HttpNotFound();
            }
            ViewBag.FK_KupacID = new SelectList(db.Kupac, "KupacID", "FK_JMBG", racun.FK_KupacID);
            ViewBag.FK_VozacID = new SelectList(db.Vozac, "VozacID", "FK_JMBG", racun.FK_VozacID);
            return View(racun);
        }

        // POST: Racuns/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RacunID,Datum_izdavanja,Iznos,FK_KupacID,FK_VozacID,Adresa")] Racun racun)
        {
            if (ModelState.IsValid)
            {
                db.Entry(racun).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FK_KupacID = new SelectList(db.Kupac, "KupacID", "FK_JMBG", racun.FK_KupacID);
            ViewBag.FK_VozacID = new SelectList(db.Vozac, "VozacID", "FK_JMBG", racun.FK_VozacID);
            return View(racun);
        }

        // GET: Racuns/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Racun racun = db.Racun.Find(id);
            if (racun == null)
            {
                return HttpNotFound();
            }
            return View(racun);
        }

        // POST: Racuns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Racun racun = db.Racun.Find(id);
            db.Racun.Remove(racun);
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
