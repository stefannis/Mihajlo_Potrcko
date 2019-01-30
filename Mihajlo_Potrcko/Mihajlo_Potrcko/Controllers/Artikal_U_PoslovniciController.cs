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
    public class Artikal_U_PoslovniciController : Controller
    {
        private Potrcko db = new Potrcko();

        // GET: Artikal_U_Poslovnici
        public ActionResult Index()
        {
            var artikal_U_Poslovnici = db.Artikal_U_Poslovnici.Include(a => a.Artikal).Include(a => a.Poslovnica);
            return View(artikal_U_Poslovnici.ToList());
        }

        // GET: Artikal_U_Poslovnici/Details/5
        public ActionResult Details(bool? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Artikal_U_Poslovnici artikal_U_Poslovnici = db.Artikal_U_Poslovnici.Find(id);
            if (artikal_U_Poslovnici == null)
            {
                return HttpNotFound();
            }
            return View(artikal_U_Poslovnici);
        }

        // GET: Artikal_U_Poslovnici/Create
        public ActionResult Create()
        {
            ViewBag.FK_ArtikalID = new SelectList(db.Artikal, "ArtikalID", "Naziv_artikla");
            ViewBag.FK_PoslovnicaID = new SelectList(db.Poslovnica, "PoslovnicaID", "Adresa");
            return View();
        }

        // POST: Artikal_U_Poslovnici/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Stanje,PoslovnicaID,ArtikalID")] Artikal_U_Poslovnici artikal_U_Poslovnici)
        {
            if (ModelState.IsValid)
            {
                db.Artikal_U_Poslovnici.Add(artikal_U_Poslovnici);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FK_ArtikalID = new SelectList(db.Artikal, "ArtikalID", "Naziv_artikla", artikal_U_Poslovnici.ArtikalID);
            ViewBag.FK_PoslovnicaID = new SelectList(db.Poslovnica, "PoslovnicaID", "Adresa", artikal_U_Poslovnici.PoslovnicaID);
            return View(artikal_U_Poslovnici);
        }

        // GET: Artikal_U_Poslovnici/Edit/5
        public ActionResult Edit(bool? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Artikal_U_Poslovnici artikal_U_Poslovnici = db.Artikal_U_Poslovnici.Find(id);
            if (artikal_U_Poslovnici == null)
            {
                return HttpNotFound();
            }
            ViewBag.FK_ArtikalID = new SelectList(db.Artikal, "ArtikalID", "Naziv_artikla", artikal_U_Poslovnici.ArtikalID);
            ViewBag.FK_PoslovnicaID = new SelectList(db.Poslovnica, "PoslovnicaID", "Adresa", artikal_U_Poslovnici.PoslovnicaID);
            return View(artikal_U_Poslovnici);
        }

        // POST: Artikal_U_Poslovnici/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Stanje,PoslovnicaID,ArtikalID")] Artikal_U_Poslovnici artikal_U_Poslovnici)
        {
            if (ModelState.IsValid)
            {
                db.Entry(artikal_U_Poslovnici).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FK_ArtikalID = new SelectList(db.Artikal, "ArtikalID", "Naziv_artikla", artikal_U_Poslovnici.ArtikalID);
            ViewBag.FK_PoslovnicaID = new SelectList(db.Poslovnica, "PoslovnicaID", "Adresa", artikal_U_Poslovnici.PoslovnicaID);
            return View(artikal_U_Poslovnici);
        }

        // GET: Artikal_U_Poslovnici/Delete/5
        public ActionResult Delete(bool? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Artikal_U_Poslovnici artikal_U_Poslovnici = db.Artikal_U_Poslovnici.Find(id);
            if (artikal_U_Poslovnici == null)
            {
                return HttpNotFound();
            }
            return View(artikal_U_Poslovnici);
        }

        // POST: Artikal_U_Poslovnici/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(bool id)
        {
            Artikal_U_Poslovnici artikal_U_Poslovnici = db.Artikal_U_Poslovnici.Find(id);
            db.Artikal_U_Poslovnici.Remove(artikal_U_Poslovnici);
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
