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
    public class KupacController : Controller
    {
        private Potrcko db = new Potrcko();

        // GET: Kupac
        public ActionResult Index()
        {
            var kupac = db.Kupac.Include(k => k.Korisnik).Include(k => k.Nalog);
            return View(new ViewDataContainer(kupac.ToList(),new MainView()));
        }


        // GET: Kupac/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kupac kupac = db.Kupac.Find(id);
            if (kupac == null)
            {
                return HttpNotFound();
            }
            return View(new ViewDataContainer(kupac, new AdminView()));
        }

        // GET: Kupac/Create
        public ActionResult Create()
        {
            ViewBag.FK_JMBG = new SelectList(db.Korisnik, "JMBG", "Ime");
            ViewBag.FK_NalogID = new SelectList(db.Nalog, "NalogID", "Username");
            return View(new ViewDataContainer(null,new AdminView()));
        }

        // POST: Kupac/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "KupacID,JMBG,NalogID")] Kupac kupac)
        {
            if (ModelState.IsValid)
            {
                db.Kupac.Add(kupac);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FK_JMBG = new SelectList(db.Korisnik, "JMBG", "Ime", kupac.JMBG);
            ViewBag.FK_NalogID = new SelectList(db.Nalog, "NalogID", "Username", kupac.NalogID);
            return View(new ViewDataContainer(kupac, new AdminView()));
        }

        // GET: Kupac/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kupac kupac = db.Kupac.Find(id);
            if (kupac == null)
            {
                return HttpNotFound();
            }
            ViewBag.FK_JMBG = new SelectList(db.Korisnik, "JMBG", "Ime", kupac.JMBG);
            ViewBag.FK_NalogID = new SelectList(db.Nalog, "NalogID", "Username", kupac.NalogID);
            return View(new ViewDataContainer(kupac, new AdminView()));
        }

        // POST: Kupac/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "KupacID,JMBG,NalogID")] Kupac kupac)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kupac).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FK_JMBG = new SelectList(db.Korisnik, "JMBG", "Ime", kupac.JMBG);
            ViewBag.FK_NalogID = new SelectList(db.Nalog, "NalogID", "Username", kupac.NalogID);
            return View(new ViewDataContainer(kupac, new AdminView()));
        }

        // GET: Kupac/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kupac kupac = db.Kupac.Find(id);
            if (kupac == null)
            {
                return HttpNotFound();
            }
            return View(new ViewDataContainer(kupac, new AdminView()));
        }

        // POST: Kupac/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Kupac kupac = db.Kupac.Find(id);
            db.Kupac.Remove(kupac);
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
