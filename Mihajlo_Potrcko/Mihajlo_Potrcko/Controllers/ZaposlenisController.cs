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
    public class ZaposlenisController : Controller
    {
        private Potrcko db = new Potrcko();

        // GET: Zaposlenis
        public ActionResult Index()
        {
            var zaposleni = db.Zaposleni.Include(z => z.Korisnik).Include(z => z.Vozac).Include(z => z.Zaposleni2);
            return View(zaposleni.ToList());
        }

        // GET: Zaposlenis/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zaposleni zaposleni = db.Zaposleni.Find(id);
            if (zaposleni == null)
            {
                return HttpNotFound();
            }
            return View(zaposleni);
        }

        // GET: Zaposlenis/Create
        public ActionResult Create()
        {
            ViewBag.FK_JMBG = new SelectList(db.Korisnik, "JMBG", "Ime");
            ViewBag.FK_VozacID = new SelectList(db.Vozac, "VozacID", "FK_JMBG");
            ViewBag.Administrator = new SelectList(db.Zaposleni, "ZaposleniID", "FK_JMBG");
            return View();
        }

        // POST: Zaposlenis/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ZaposleniID,FK_VozacID,FK_JMBG,Administrator")] Zaposleni zaposleni)
        {
            if (ModelState.IsValid)
            {
                db.Zaposleni.Add(zaposleni);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FK_JMBG = new SelectList(db.Korisnik, "JMBG", "Ime", zaposleni.FK_JMBG);
            ViewBag.FK_VozacID = new SelectList(db.Vozac, "VozacID", "FK_JMBG", zaposleni.FK_VozacID);
            ViewBag.Administrator = new SelectList(db.Zaposleni, "ZaposleniID", "FK_JMBG", zaposleni.Administrator);
            return View(zaposleni);
        }

        // GET: Zaposlenis/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zaposleni zaposleni = db.Zaposleni.Find(id);
            if (zaposleni == null)
            {
                return HttpNotFound();
            }
            ViewBag.FK_JMBG = new SelectList(db.Korisnik, "JMBG", "Ime", zaposleni.FK_JMBG);
            ViewBag.FK_VozacID = new SelectList(db.Vozac, "VozacID", "FK_JMBG", zaposleni.FK_VozacID);
            ViewBag.Administrator = new SelectList(db.Zaposleni, "ZaposleniID", "FK_JMBG", zaposleni.Administrator);
            return View(zaposleni);
        }

        // POST: Zaposlenis/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ZaposleniID,FK_VozacID,FK_JMBG,Administrator")] Zaposleni zaposleni)
        {
            if (ModelState.IsValid)
            {
                db.Entry(zaposleni).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FK_JMBG = new SelectList(db.Korisnik, "JMBG", "Ime", zaposleni.FK_JMBG);
            ViewBag.FK_VozacID = new SelectList(db.Vozac, "VozacID", "FK_JMBG", zaposleni.FK_VozacID);
            ViewBag.Administrator = new SelectList(db.Zaposleni, "ZaposleniID", "FK_JMBG", zaposleni.Administrator);
            return View(zaposleni);
        }

        // GET: Zaposlenis/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zaposleni zaposleni = db.Zaposleni.Find(id);
            if (zaposleni == null)
            {
                return HttpNotFound();
            }
            return View(zaposleni);
        }

        // POST: Zaposlenis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Zaposleni zaposleni = db.Zaposleni.Find(id);
            db.Zaposleni.Remove(zaposleni);
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
