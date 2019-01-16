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
    public class NalogController : Controller
    {
        private PotrckoDB db = new PotrckoDB();

        // GET: Nalogs
        public ActionResult Index()
        {
            var nalog = db.Nalog.Include(n => n.Korisnik).Include(n => n.Slika);
            return View(nalog.ToList());
        }

        // GET: Nalogs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nalog nalog = db.Nalog.Find(id);
            if (nalog == null)
            {
                return HttpNotFound();
            }
            return View(nalog);
        }

        // GET: Nalogs/Create
        public ActionResult Create()
        {
            ViewBag.FK_JMBG = new SelectList(db.Korisnik, "JMBG", "Ime");
            ViewBag.FK_SlikaID = new SelectList(db.Slika, "SlikaID", "Link");
            return View();
        }

        // POST: Nalogs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NalogID,Username,Password,FK_JMBG,FK_SlikaID")] Nalog nalog)
        {
            if (ModelState.IsValid)
            {
                db.Nalog.Add(nalog);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FK_JMBG = new SelectList(db.Korisnik, "JMBG", "Ime", nalog.FK_JMBG);
            ViewBag.FK_SlikaID = new SelectList(db.Slika, "SlikaID", "Link", nalog.FK_SlikaID);
            return View(nalog);
        }

        // GET: Nalogs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nalog nalog = db.Nalog.Find(id);
            if (nalog == null)
            {
                return HttpNotFound();
            }
            ViewBag.FK_JMBG = new SelectList(db.Korisnik, "JMBG", "Ime", nalog.FK_JMBG);
            ViewBag.FK_SlikaID = new SelectList(db.Slika, "SlikaID", "Link", nalog.FK_SlikaID);
            return View(nalog);
        }

        // POST: Nalogs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NalogID,Username,Password,FK_JMBG,FK_SlikaID")] Nalog nalog)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nalog).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FK_JMBG = new SelectList(db.Korisnik, "JMBG", "Ime", nalog.FK_JMBG);
            ViewBag.FK_SlikaID = new SelectList(db.Slika, "SlikaID", "Link", nalog.FK_SlikaID);
            return View(nalog);
        }

        // GET: Nalogs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nalog nalog = db.Nalog.Find(id);
            if (nalog == null)
            {
                return HttpNotFound();
            }
            return View(nalog);
        }

        // POST: Nalogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Nalog nalog = db.Nalog.Find(id);
            db.Nalog.Remove(nalog);
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
