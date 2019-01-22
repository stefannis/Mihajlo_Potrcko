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
    public class PoslovnicaController : MainViewController
    {
        private Potrcko db = new Potrcko();

        // GET: Poslovnica
        public ActionResult Index()
        {
            var poslovnica = db.Poslovnica.Include(p => p.Partner);
            return View(new MainView<IEnumerable<Poslovnica>>(poslovnica.ToList(),"Poslovnice"));
        }

        // GET: Poslovnica/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Poslovnica poslovnica = db.Poslovnica.Find(id);
            if (poslovnica == null)
            {
                return HttpNotFound();
            }
            return View(new MainView<Poslovnica>(poslovnica,"Poslovnica kontroler"));
        }

        // GET: Poslovnica/Create
        public ActionResult Create()
        {
            ViewBag.FK_PartnerID = new SelectList(db.Partner, "PartnerID", "Naziv");
            return View();
        }

        // POST: Poslovnica/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PoslovnicaID,Adresa,Broj_telefona,FK_PartnerID")] Poslovnica poslovnica)
        {
            if (ModelState.IsValid)
            {
                db.Poslovnica.Add(poslovnica);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FK_PartnerID = new SelectList(db.Partner, "PartnerID", "Naziv", poslovnica.FK_PartnerID);
            return View(poslovnica);
        }

        // GET: Poslovnica/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Poslovnica poslovnica = db.Poslovnica.Find(id);
            if (poslovnica == null)
            {
                return HttpNotFound();
            }
            ViewBag.FK_PartnerID = new SelectList(db.Partner, "PartnerID", "Naziv", poslovnica.FK_PartnerID);
            return View(new MainView<Poslovnica>(poslovnica,"Ime"));
        }

        // POST: Poslovnica/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PoslovnicaID,Adresa,Broj_telefona,FK_PartnerID")] Poslovnica poslovnica)
        {
            if (ModelState.IsValid)
            {
                db.Entry(poslovnica).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FK_PartnerID = new SelectList(db.Partner, "PartnerID", "Naziv", poslovnica.FK_PartnerID);
            return View(new MainView<Poslovnica>(poslovnica, "Ime"));
        }

        // GET: Poslovnica/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Poslovnica poslovnica = db.Poslovnica.Find(id);
            if (poslovnica == null)
            {
                return HttpNotFound();
            }
            return View(poslovnica);
        }

        // POST: Poslovnica/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Poslovnica poslovnica = db.Poslovnica.Find(id);
            db.Poslovnica.Remove(poslovnica);
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
