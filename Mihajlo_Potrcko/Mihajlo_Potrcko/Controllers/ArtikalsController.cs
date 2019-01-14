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
    public class ArtikalsController : Controller
    {
        private Potrcko db = new Potrcko();

        // GET: Artikals
        public ActionResult Index()
        {
            var artikal = db.Artikal.Include(a => a.Slika);
            return View(artikal.ToList());
        }

        // GET: Artikals/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Artikal artikal = db.Artikal.Find(id);
            if (artikal == null)
            {
                return HttpNotFound();
            }
            return View(artikal);
        }

        // GET: Artikals/Create
        public ActionResult Create()
        {
            ViewBag.FK_SlikaID = new SelectList(db.Slika, "SlikaID", "Link");
            return View();
        }

        // POST: Artikals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ArtikalID,Naziv_artikla,Cena_artikla,FK_SlikaID")] Artikal artikal)
        {
            if (ModelState.IsValid)
            {
                db.Artikal.Add(artikal);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FK_SlikaID = new SelectList(db.Slika, "SlikaID", "Link", artikal.FK_SlikaID);
            return View(artikal);
        }

        // GET: Artikals/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Artikal artikal = db.Artikal.Find(id);
            if (artikal == null)
            {
                return HttpNotFound();
            }
            ViewBag.FK_SlikaID = new SelectList(db.Slika, "SlikaID", "Link", artikal.FK_SlikaID);
            return View(artikal);
        }

        // POST: Artikals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ArtikalID,Naziv_artikla,Cena_artikla,FK_SlikaID")] Artikal artikal)
        {
            if (ModelState.IsValid)
            {
                db.Entry(artikal).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FK_SlikaID = new SelectList(db.Slika, "SlikaID", "Link", artikal.FK_SlikaID);
            return View(artikal);
        }

        // GET: Artikals/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Artikal artikal = db.Artikal.Find(id);
            if (artikal == null)
            {
                return HttpNotFound();
            }
            return View(artikal);
        }

        // POST: Artikals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Artikal artikal = db.Artikal.Find(id);
            db.Artikal.Remove(artikal);
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
