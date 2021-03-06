﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Mihajlo_Potrcko.Components;
using Mihajlo_Potrcko.LayoutViews;
using Mihajlo_Potrcko.Models;
using EntityState = System.Data.Entity.EntityState;

namespace Mihajlo_Potrcko.Controllers
{
    public class PartnerController : Controller
    {
        private Potrcko db = new Potrcko();

        // GET: Partner
        public ActionResult Index()
        {
            var partner = db.Partner.Include(p => p.Slika);
            return View(new ViewDataContainer(partner.ToList(), new AdminView()));
        }

        // GET: Partner/Details/5
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
            return View(new ViewDataContainer(partner, new AdminView()));
        }

        // GET: Partner/Create
        public ActionResult Create()
        {
            ViewBag.FK_SlikaID = new SelectList(db.Slika, "SlikaID", "Link");
            return View(new ViewDataContainer(null, new AdminView()));
        }

        // POST: Partner/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PartnerID,Naziv,Procenat_zarade,Datum_pocetka_poslovanja,Kategorija,SlikaID")] Partner partner)
        {
            if (ModelState.IsValid)
            {
                db.Partner.Add(partner);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FK_SlikaID = new SelectList(db.Slika, "SlikaID", "Link", partner.SlikaID);
            return View(new ViewDataContainer(partner, new AdminView()));
        }

        // GET: Partner/Edit/5
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
            ViewBag.FK_SlikaID = new SelectList(db.Slika, "SlikaID", "Link", partner.SlikaID);
            return View(new ViewDataContainer(partner, new AdminView()));
        }

        // POST: Partner/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PartnerID,Naziv,Procenat_zarade,Datum_pocetka_poslovanja,Kategorija,SlikaID")] Partner partner)
        {
            if (ModelState.IsValid)
            {
                db.Entry(partner).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FK_SlikaID = new SelectList(db.Slika, "SlikaID", "Link", partner.SlikaID);
            return View(new ViewDataContainer(partner, new AdminView()));
        }

        // GET: Partner/Delete/5
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
            return View(new ViewDataContainer(partner, new AdminView()));
        }

        // POST: Partner/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Partner partner = db.Partner.Find(id);
            db.Partner.Remove(partner);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult PartneriPoKategoriji(string kategorija)
        {
            
            return View(new ViewDataContainer(db.Partner.Where(par => par.Kategorija.Equals(kategorija)), new MainView()));
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
