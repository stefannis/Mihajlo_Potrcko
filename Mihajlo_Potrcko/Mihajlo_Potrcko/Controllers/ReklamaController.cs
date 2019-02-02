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
    public class ReklamaController : Controller
    {
        private Potrcko db = new Potrcko();

        // GET: Reklama
        public ActionResult Index()
        {
            var reklama = db.Reklama.Include(r => r.Slika);
            return View(new ViewDataContainer(reklama.ToList(), new AdminView()));
        }

        // GET: Reklama/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reklama reklama = db.Reklama.Find(id);
            if (reklama == null)
            {
                return HttpNotFound();
            }
            return View(reklama);
        }

        // GET: Reklama/Create
        public ActionResult Create()
        {
            ViewBag.FK_SlikaID = new SelectList(db.Slika, "SlikaID", "Link");
            return View();
        }

        // POST: Reklama/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ReklamaID,Naziv_kupca,Datum_isteka,SlikaID")] Reklama reklama)
        {
            if (ModelState.IsValid)
            {
                db.Reklama.Add(reklama);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FK_SlikaID = new SelectList(db.Slika, "SlikaID", "Link", reklama.SlikaID);
            return View(reklama);
        }

        // GET: Reklama/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reklama reklama = db.Reklama.Find(id);
            if (reklama == null)
            {
                return HttpNotFound();
            }
            ViewBag.FK_SlikaID = new SelectList(db.Slika, "SlikaID", "Link", reklama.SlikaID);
            return View(reklama);
        }

        // POST: Reklama/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ReklamaID,Naziv_kupca,Datum_isteka,SlikaID")] Reklama reklama)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reklama).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FK_SlikaID = new SelectList(db.Slika, "SlikaID", "Link", reklama.SlikaID);
            return View(reklama);
        }

        // GET: Reklama/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reklama reklama = db.Reklama.Find(id);
            if (reklama == null)
            {
                return HttpNotFound();
            }
            return View(reklama);
        }

        // POST: Reklama/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Reklama reklama = db.Reklama.Find(id);
            db.Reklama.Remove(reklama);
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
