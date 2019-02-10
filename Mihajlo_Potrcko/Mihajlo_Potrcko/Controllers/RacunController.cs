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
    public class RacunController : Controller
    {
        private Potrcko db = new Potrcko();

        // GET: Racun
        public ActionResult Index()
        {
            var racun = db.Racun.Include(r => r.Kupac).Include(r => r.Vozac);
            return View(new ViewDataContainer(racun.ToList(), new AdminView()));
        }

        // GET: Racun/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Racun racun = db.Racun.Find(id);
            if (racun == null)
            {
                return HttpNotFound();
            }
            return View(new ViewDataContainer(racun, new AdminView()));
        }

        // GET: Racun/Create
        public ActionResult Create()
        {
            ViewBag.FK_KupacID = new SelectList(db.Kupac, "KupacID", "JMBG");
            ViewBag.FK_VozacID = new SelectList(db.Vozac, "VozacID", "VozacID");
            return View(new ViewDataContainer(null, new AdminView()));
        }

        // POST: Racun/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RacunID,Datum_izdavanja,Iznos,KupacID,VozacID,Adresa")] Racun racun)
        {
            if (ModelState.IsValid)
            {
                db.Racun.Add(racun);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FK_KupacID = new SelectList(db.Kupac, "KupacID", "JMBG", racun.KupacID);
            ViewBag.FK_VozacID = new SelectList(db.Vozac, "VozacID", "VozacID", racun.VozacID);
            return View(new ViewDataContainer(racun, new AdminView()));
        }

        // GET: Racun/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Racun racun = db.Racun.Find(id);
            if (racun == null)
            {
                return HttpNotFound();
            }
            ViewBag.FK_KupacID = new SelectList(db.Kupac, "KupacID", "JMBG", racun.KupacID);
            ViewBag.FK_VozacID = new SelectList(db.Vozac, "VozacID", "VozacID", racun.VozacID);
            return View(new ViewDataContainer(racun, new AdminView()));
        }

        // POST: Racun/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RacunID,Datum_izdavanja,Iznos,KupacID,VozacID,Adresa")] Racun racun)
        {
            if (ModelState.IsValid)
            {
                db.Entry(racun).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FK_KupacID = new SelectList(db.Kupac, "KupacID", "JMBG", racun.KupacID);
            ViewBag.FK_VozacID = new SelectList(db.Vozac, "VozacID", "VozacID", racun.VozacID);
            return View(new ViewDataContainer(racun, new AdminView()));
        }

        // GET: Racun/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Racun racun = db.Racun.Find(id);
            if (racun == null)
            {
                return HttpNotFound();
            }
            return View(new ViewDataContainer(racun, new AdminView()));
        }

        // POST: Racun/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Racun racun = db.Racun.Find(id);
            db.Racun.Remove(racun);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult RacunKorisnika(string JMBG, int? racunID)
        {
            dynamic listaRacuna;
            if (racunID != null)
            {
                int idRacuna = (int) racunID;
                listaRacuna = db.Racun.Where(rac => rac.RacunID.Equals(idRacuna));
                return View(new ViewDataContainer(listaRacuna, new MainView()));
            }

            if (JMBG != "")
            {
                listaRacuna = db.Racun.Where(rac => rac.Kupac.JMBG.Equals(JMBG)).ToList();
                return View(new ViewDataContainer(listaRacuna, new MainView()));
            }
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

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
