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
using Mihajlo_Potrcko.Components;
using Mihajlo_Potrcko.LayoutViews;

namespace Mihajlo_Potrcko.Controllers
{
    public class NalogController : Controller
    {
        private Potrcko db = new Potrcko();

        // GET: Nalog
        public ActionResult Index()
        {
            var nalog = db.Nalog.Include(n => n.Korisnik).Include(n => n.Slika);
            return View(new ViewDataContainer(nalog.ToList(), new AdminView()));
        }

        // GET: Nalog/Details/5
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
            return View(new ViewDataContainer(nalog, new AdminView()));
        }

        // GET: Nalog/Create
        public ActionResult Create()
        {
            ViewBag.FK_JMBG = new SelectList(db.Korisnik, "JMBG", "Ime");
            ViewBag.FK_SlikaID = new SelectList(db.Slika, "SlikaID", "Link");
            return View(new ViewDataContainer(null, new AdminView()));
        }

        // POST: Nalog/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NalogID,Username,Password,JMBG,SlikaID")] Nalog nalog)
        {
            if (ModelState.IsValid)
            {
                db.Nalog.Add(nalog);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FK_JMBG = new SelectList(db.Korisnik, "JMBG", "Ime", nalog.JMBG);
            ViewBag.FK_SlikaID = new SelectList(db.Slika, "SlikaID", "Link", nalog.SlikaID);
            return View(new ViewDataContainer(nalog, new AdminView()));
        }

        // GET: Nalog/Edit/5
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
            ViewBag.FK_JMBG = new SelectList(db.Korisnik, "JMBG", "Ime", nalog.JMBG);
            ViewBag.FK_SlikaID = new SelectList(db.Slika, "SlikaID", "Link", nalog.SlikaID);
            return View(new ViewDataContainer(nalog, new AdminView()));
        }

        // POST: Nalog/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NalogID,Username,Password,JMBG,SlikaID")] Nalog nalog)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nalog).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FK_JMBG = new SelectList(db.Korisnik, "JMBG", "Ime", nalog.JMBG);
            ViewBag.FK_SlikaID = new SelectList(db.Slika, "SlikaID", "Link", nalog.SlikaID);
            return View(new ViewDataContainer(nalog, new AdminView()));
        }

        // GET: Nalog/Delete/5
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
            return View(new ViewDataContainer(nalog, new AdminView()));
        }

        // POST: Nalog/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Nalog nalog = db.Nalog.Find(id);
            db.Nalog.Remove(nalog);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult korisnickiNalog(int? id)
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
            return View(new ViewDataContainer(nalog, new MainView()));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult parseEdit([Bind(Include = "NalogID,Username,Password,JMBG,SlikaID")] Nalog nalog)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nalog).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }

            return RedirectToAction("korisnickiNalog", "Nalog");
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
