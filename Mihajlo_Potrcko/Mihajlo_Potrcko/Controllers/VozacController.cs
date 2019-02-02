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
    public class VozacController : Controller
    {
        private Potrcko db = new Potrcko();

        // GET: Vozac
        public ActionResult Index()
        {
            var vozac = db.Vozac.Include(v => v.Nalog).Include(v => v.Zaposleni);
            return View(new ViewDataContainer(vozac.ToList(), new AdminView()));
        }

        // GET: Vozac/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vozac vozac = db.Vozac.Find(id);
            if (vozac == null)
            {
                return HttpNotFound();
            }
            return View(vozac);
        }

        // GET: Vozac/Create
        public ActionResult Create()
        {
            ViewBag.FK_NalogID = new SelectList(db.Nalog, "NalogID", "Username");
            ViewBag.FK_ZaposleniID = new SelectList(db.Zaposleni, "ZaposleniID", "JMBG");
            return View();
        }

        // POST: Vozac/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VozacID,ZaposleniID,NalogID")] Vozac vozac)
        {
            if (ModelState.IsValid)
            {
                db.Vozac.Add(vozac);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FK_NalogID = new SelectList(db.Nalog, "NalogID", "Username", vozac.NalogID);
            ViewBag.FK_ZaposleniID = new SelectList(db.Zaposleni, "ZaposleniID", "JMBG", vozac.ZaposleniID);
            return View(vozac);
        }

        // GET: Vozac/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vozac vozac = db.Vozac.Find(id);
            if (vozac == null)
            {
                return HttpNotFound();
            }
            ViewBag.FK_NalogID = new SelectList(db.Nalog, "NalogID", "Username", vozac.NalogID);
            ViewBag.FK_ZaposleniID = new SelectList(db.Zaposleni, "ZaposleniID", "JMBG", vozac.ZaposleniID);
            return View(vozac);
        }

        // POST: Vozac/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VozacID,ZaposleniID,NalogID")] Vozac vozac)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vozac).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FK_NalogID = new SelectList(db.Nalog, "NalogID", "Username", vozac.NalogID);
            ViewBag.FK_ZaposleniID = new SelectList(db.Zaposleni, "ZaposleniID", "JMBG", vozac.ZaposleniID);
            return View(vozac);
        }

        // GET: Vozac/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vozac vozac = db.Vozac.Find(id);
            if (vozac == null)
            {
                return HttpNotFound();
            }
            return View(vozac);
        }

        // POST: Vozac/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vozac vozac = db.Vozac.Find(id);
            db.Vozac.Remove(vozac);
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
