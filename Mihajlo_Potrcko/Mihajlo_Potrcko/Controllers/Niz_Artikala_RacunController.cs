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
    public class Niz_Artikala_RacunController : Controller
    {
        private Potrcko db = new Potrcko();

        // GET: Niz_Artikala_Racun
        public ActionResult Index()
        {
            var niz_Artikala_Racun = db.Niz_Artikala_Racun.Include(n => n.Artikal).Include(n => n.Racun);
            return View(new ViewDataContainer(niz_Artikala_Racun.ToList(), new MainView()));
        }

        // GET: Niz_Artikala_Racun/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Niz_Artikala_Racun niz_Artikala_Racun = db.Niz_Artikala_Racun.Find(id);
            if (niz_Artikala_Racun == null)
            {
                return HttpNotFound();
            }
            return View(new ViewDataContainer(niz_Artikala_Racun, new AdminView()));
        }

        // GET: Niz_Artikala_Racun/Create
        public ActionResult Create()
        {
            ViewBag.FK_ArtikalID = new SelectList(db.Artikal, "ArtikalID", "Naziv_artikla");
            ViewBag.FK_RacunID = new SelectList(db.Racun, "RacunID", "Adresa");
            return View(new ViewDataContainer(null, new AdminView()));
        }

        // POST: Niz_Artikala_Racun/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Niz_artikla_racunID,Kolicina,RacunID,ArtikalID")] Niz_Artikala_Racun niz_Artikala_Racun)
        {
            if (ModelState.IsValid)
            {
                db.Niz_Artikala_Racun.Add(niz_Artikala_Racun);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FK_ArtikalID = new SelectList(db.Artikal, "ArtikalID", "Naziv_artikla", niz_Artikala_Racun.ArtikalID);
            ViewBag.FK_RacunID = new SelectList(db.Racun, "RacunID", "Adresa", niz_Artikala_Racun.RacunID);
            return View(new ViewDataContainer(niz_Artikala_Racun, new AdminView()));
        }

        // GET: Niz_Artikala_Racun/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Niz_Artikala_Racun niz_Artikala_Racun = db.Niz_Artikala_Racun.Find(id);
            if (niz_Artikala_Racun == null)
            {
                return HttpNotFound();
            }
            ViewBag.FK_ArtikalID = new SelectList(db.Artikal, "ArtikalID", "Naziv_artikla", niz_Artikala_Racun.ArtikalID);
            ViewBag.FK_RacunID = new SelectList(db.Racun, "RacunID", "Adresa", niz_Artikala_Racun.RacunID);
            return View(new ViewDataContainer(niz_Artikala_Racun, new AdminView()));
        }

        // POST: Niz_Artikala_Racun/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Niz_artikla_racunID,Kolicina,RacunID,ArtikalID")] Niz_Artikala_Racun niz_Artikala_Racun)
        {
            if (ModelState.IsValid)
            {
                db.Entry(niz_Artikala_Racun).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FK_ArtikalID = new SelectList(db.Artikal, "ArtikalID", "Naziv_artikla", niz_Artikala_Racun.ArtikalID);
            ViewBag.FK_RacunID = new SelectList(db.Racun, "RacunID", "Adresa", niz_Artikala_Racun.RacunID);
            return View(new ViewDataContainer(niz_Artikala_Racun, new AdminView()));
        }

        // GET: Niz_Artikala_Racun/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Niz_Artikala_Racun niz_Artikala_Racun = db.Niz_Artikala_Racun.Find(id);
            if (niz_Artikala_Racun == null)
            {
                return HttpNotFound();
            }
            return View(new ViewDataContainer(niz_Artikala_Racun, new AdminView()));
        }

        // POST: Niz_Artikala_Racun/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Niz_Artikala_Racun niz_Artikala_Racun = db.Niz_Artikala_Racun.Find(id);
            db.Niz_Artikala_Racun.Remove(niz_Artikala_Racun);
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
