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
    public class PartnersController : Controller
    {
        private Potrcko db = new Potrcko();

        // GET: Partners
        public ActionResult Index()
        {
            var partner = db.Partner.Include(p => p.Slika);
            return View(partner.ToList());
        }

        // GET: Partners/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Partner partner = db.Partner.Find(id);
            if (partner == null)
            {
                return HttpNotFound();
            }
            return View(partner);
        }

        // GET: Partners/Create
        public ActionResult Create()
        {
            ViewBag.FK_SlikaID = new SelectList(db.Slika, "SlikaID", "Link");
            return View();
        }

        // POST: Partners/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PartnerID,Naziv,Procenat_zarade,Datum_pocetka_poslovanja,Kategorija,FK_SlikaID")] Partner partner)
        {
            if (ModelState.IsValid)
            {
                db.Partner.Add(partner);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FK_SlikaID = new SelectList(db.Slika, "SlikaID", "Link", partner.FK_SlikaID);
            return View(partner);
        }

        // GET: Partners/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Partner partner = db.Partner.Find(id);
            if (partner == null)
            {
                return HttpNotFound();
            }
            ViewBag.FK_SlikaID = new SelectList(db.Slika, "SlikaID", "Link", partner.FK_SlikaID);
            return View(partner);
        }

        // POST: Partners/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PartnerID,Naziv,Procenat_zarade,Datum_pocetka_poslovanja,Kategorija,FK_SlikaID")] Partner partner)
        {
            if (ModelState.IsValid)
            {
                db.Entry(partner).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FK_SlikaID = new SelectList(db.Slika, "SlikaID", "Link", partner.FK_SlikaID);
            return View(partner);
        }

        // GET: Partners/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Partner partner = db.Partner.Find(id);
            if (partner == null)
            {
                return HttpNotFound();
            }
            return View(partner);
        }

        // POST: Partners/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Partner partner = db.Partner.Find(id);
            db.Partner.Remove(partner);
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
