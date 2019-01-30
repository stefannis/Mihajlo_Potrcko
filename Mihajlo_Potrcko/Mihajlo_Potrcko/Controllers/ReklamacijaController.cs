﻿using System;
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
    public class ReklamacijaController : Controller
    {
        private Potrcko db = new Potrcko();

        // GET: Reklamacija
        public ActionResult Index()
        {
            var reklamacija = db.Reklamacija.Include(r => r.Racun);
            return View(reklamacija.ToList());
        }

        // GET: Reklamacija/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reklamacija reklamacija = db.Reklamacija.Find(id);
            if (reklamacija == null)
            {
                return HttpNotFound();
            }
            return View(reklamacija);
        }

        // GET: Reklamacija/Create
        public ActionResult Create()
        {
            ViewBag.FK_RacunID = new SelectList(db.Racun, "RacunID", "Adresa");
            return View();
        }

        // POST: Reklamacija/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ReklamacijaID,RacunID,Opis")] Reklamacija reklamacija)
        {
            if (ModelState.IsValid)
            {
                db.Reklamacija.Add(reklamacija);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FK_RacunID = new SelectList(db.Racun, "RacunID", "Adresa", reklamacija.RacunID);
            return View(reklamacija);
        }

        // GET: Reklamacija/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reklamacija reklamacija = db.Reklamacija.Find(id);
            if (reklamacija == null)
            {
                return HttpNotFound();
            }
            ViewBag.FK_RacunID = new SelectList(db.Racun, "RacunID", "Adresa", reklamacija.RacunID);
            return View(reklamacija);
        }

        // POST: Reklamacija/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ReklamacijaID,RacunID,Opis")] Reklamacija reklamacija)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reklamacija).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FK_RacunID = new SelectList(db.Racun, "RacunID", "Adresa", reklamacija.RacunID);
            return View(reklamacija);
        }

        // GET: Reklamacija/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reklamacija reklamacija = db.Reklamacija.Find(id);
            if (reklamacija == null)
            {
                return HttpNotFound();
            }
            return View(reklamacija);
        }

        // POST: Reklamacija/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Reklamacija reklamacija = db.Reklamacija.Find(id);
            db.Reklamacija.Remove(reklamacija);
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
