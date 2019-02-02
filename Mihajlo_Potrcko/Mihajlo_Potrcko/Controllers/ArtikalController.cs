using System;
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
    public class ArtikalController : Controller
    {
        private Potrcko db = new Potrcko();

        // GET: Artikal
        public ActionResult Index()
        {
            var artikal = db.Artikal.Include(a => a.Slika);
            return View(new ViewDataContainer(artikal.ToList(), new MainView()));
        }

        // GET: Artikal/Details/5
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

        // GET: Artikal/Create
        public ActionResult Create()
        {
            ViewBag.FK_SlikaID = new SelectList(db.Slika, "SlikaId", "Link");
            return View();
        }

        // POST: Artikal/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ArtikalId,NazivArtikla,CenaArtikla,FkSlikaId")] Artikal artikal)
        {
            if (ModelState.IsValid)
            {
                db.Artikal.Add(artikal);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FK_SlikaID = new SelectList(db.Slika, "SlikaId", "Link", artikal.SlikaID);
            return View(artikal);
        }

        // GET: Artikal/Edit/5
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
            ViewBag.FK_SlikaID = new SelectList(db.Slika, "SlikaId", "Link", artikal.SlikaID);
            return View(artikal);
        }

        // POST: Artikal/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ArtikalId,NazivArtikla,CenaArtikla,FkSlikaId")] Artikal artikal)
        {
            if (ModelState.IsValid)
            {
                db.Entry(artikal).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FK_SlikaID = new SelectList(db.Slika, "SlikaId", "Link", artikal.SlikaID);
            return View(artikal);
        }

        // GET: Artikal/Delete/5
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

        // POST: Artikal/Delete/5
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
