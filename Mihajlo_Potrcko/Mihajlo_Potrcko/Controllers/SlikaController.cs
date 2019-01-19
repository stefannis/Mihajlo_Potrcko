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
    public class SlikaController : Controller
    {
        private Potrcko db = new Potrcko();

        // GET: Slika
        public ActionResult Index()
        {
            return View(db.Slika.ToList());
        }

        // GET: Slika/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Slika slika = db.Slika.Find(id);
            if (slika == null)
            {
                return HttpNotFound();
            }
            return View(slika);
        }

        // GET: Slika/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Slika/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SlikaID,Link")] Slika slika)
        {
            if (ModelState.IsValid)
            {
                db.Slika.Add(slika);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(slika);
        }

        // GET: Slika/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Slika slika = db.Slika.Find(id);
            if (slika == null)
            {
                return HttpNotFound();
            }
            return View(slika);
        }

        // POST: Slika/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SlikaID,Link")] Slika slika)
        {
            if (ModelState.IsValid)
            {
                db.Entry(slika).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(slika);
        }

        // GET: Slika/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Slika slika = db.Slika.Find(id);
            if (slika == null)
            {
                return HttpNotFound();
            }
            return View(slika);
        }

        // POST: Slika/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Slika slika = db.Slika.Find(id);
            db.Slika.Remove(slika);
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
