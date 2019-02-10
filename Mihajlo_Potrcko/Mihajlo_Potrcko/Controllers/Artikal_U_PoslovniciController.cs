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
    public class Artikal_U_PoslovniciController : Controller
    {
        private Potrcko db = new Potrcko();

        // GET: Artikal_U_Poslovnici
        public ActionResult Index()
        {
            var artikalUPoslovnici = db.Artikal_U_Poslovnici.Include(a => a.Artikal).Include(a => a.Poslovnica);
            return View(new ViewDataContainer(artikalUPoslovnici.ToList(), new AdminView()));
        }

        // GET: Artikal_U_Poslovnici/Details/5
        public ActionResult Details(int? idPoslovnice, int? idArtikla)
        {
            if (idPoslovnice == null || idArtikla == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var poslovnicaId = (int)idPoslovnice;
            var artikalId = (int)idArtikla;
            var artikalUPoslovnici = db.Artikal_U_Poslovnici.First(aup => aup.PoslovnicaID.Equals(poslovnicaId) && aup.ArtikalID.Equals(artikalId));
            if (artikalUPoslovnici == null)
            {
                return HttpNotFound();
            }
            ViewBag.FK_ArtikalID = new SelectList(db.Artikal, "ArtikalID", "Naziv_artikla", artikalUPoslovnici.ArtikalID);
            ViewBag.FK_PoslovnicaID = new SelectList(db.Poslovnica, "PoslovnicaID", "Adresa", artikalUPoslovnici.PoslovnicaID);
            return View(new ViewDataContainer(artikalUPoslovnici, new AdminView()));
        }

        // GET: Artikal_U_Poslovnici/Create
        public ActionResult Create()
        {
            ViewBag.FK_ArtikalID = new SelectList(db.Artikal, "ArtikalID", "Naziv_artikla");
            ViewBag.FK_PoslovnicaID = new SelectList(db.Poslovnica, "PoslovnicaID", "Adresa");
            return View(new ViewDataContainer(null, new AdminView()));
        }

        // POST: Artikal_U_Poslovnici/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Stanje,PoslovnicaID,ArtikalID")] Artikal_U_Poslovnici artikal_U_Poslovnici)
        {
            if (ModelState.IsValid)
            {
                db.Artikal_U_Poslovnici.Add(artikal_U_Poslovnici);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FK_ArtikalID = new SelectList(db.Artikal, "ArtikalID", "Naziv_artikla", artikal_U_Poslovnici.ArtikalID);
            ViewBag.FK_PoslovnicaID = new SelectList(db.Poslovnica, "PoslovnicaID", "Adresa", artikal_U_Poslovnici.PoslovnicaID);
            return View(new ViewDataContainer(artikal_U_Poslovnici, new AdminView()));
        }

        // GET: Artikal_U_Poslovnici/Edit/5
        public ActionResult Edit(int? idPoslovnice, int? idArtikla)
        {
            if (idPoslovnice == null || idArtikla == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var PoslovnicaID = (int) idPoslovnice;
            var ArtikalID = (int) idArtikla;
            var artikalUPoslovnici = db.Artikal_U_Poslovnici.First(
                aup => aup.PoslovnicaID.Equals(PoslovnicaID) && aup.ArtikalID.Equals(ArtikalID));
            if (artikalUPoslovnici == null)
            {
                return HttpNotFound();
            }
            ViewBag.FK_ArtikalID = new SelectList(db.Artikal, "ArtikalID", "Naziv_artikla", artikalUPoslovnici.ArtikalID);
            ViewBag.FK_PoslovnicaID = new SelectList(db.Poslovnica, "PoslovnicaID", "Adresa", artikalUPoslovnici.PoslovnicaID);
            return View(new ViewDataContainer(artikalUPoslovnici, new AdminView()));
        }

        // POST: Artikal_U_Poslovnici/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Stanje,PoslovnicaID,ArtikalID")] Artikal_U_Poslovnici artikal_U_Poslovnici)
        {
            if (ModelState.IsValid)
            {
                db.Entry(artikal_U_Poslovnici).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FK_ArtikalID = new SelectList(db.Artikal, "ArtikalID", "Naziv_artikla", artikal_U_Poslovnici.ArtikalID);
            ViewBag.FK_PoslovnicaID = new SelectList(db.Poslovnica, "PoslovnicaID", "Adresa", artikal_U_Poslovnici.PoslovnicaID);
            return View(new ViewDataContainer(artikal_U_Poslovnici, new AdminView()));
        }

        // GET: Artikal_U_Poslovnici/Delete/5
        public ActionResult Delete(int? idPoslovnice, int? idArtikla)
        {
            if (idPoslovnice == null || idArtikla == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            int PoslovnicaID = (int)idPoslovnice;
            int ArtikalID = (int)idArtikla;
            Artikal_U_Poslovnici artikalUPoslovnici = db.Artikal_U_Poslovnici.First(aup => aup.PoslovnicaID.Equals(PoslovnicaID) && aup.ArtikalID.Equals(ArtikalID));
            if (artikalUPoslovnici == null)
            {
                return HttpNotFound();
            }
            return View(new ViewDataContainer(artikalUPoslovnici, new AdminView()));
        }

        // POST: Artikal_U_Poslovnici/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? idPoslovnice, int? idArtikla)
        {
            int PoslovnicaID = (int)idPoslovnice;
            int ArtikalID = (int)idArtikla;
            Artikal_U_Poslovnici artikalUPoslovnici = db.Artikal_U_Poslovnici.First(aup => aup.PoslovnicaID.Equals(PoslovnicaID) && aup.ArtikalID.Equals(ArtikalID));
            db.Artikal_U_Poslovnici.Remove(artikalUPoslovnici);
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
