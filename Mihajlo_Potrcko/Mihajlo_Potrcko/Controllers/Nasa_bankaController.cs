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
    public class Nasa_bankaController : Controller
    {
        private Potrcko db = new Potrcko();

        // GET: Nasa_banka
        public ActionResult Index()
        {
            return View(new ViewDataContainer(db.Nasa_banka.ToList(), new AdminView()));
        }

        // GET: Nasa_banka/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nasa_banka nasa_banka = db.Nasa_banka.Find(id);
            if (nasa_banka == null)
            {
                return HttpNotFound();
            }
            return View(new ViewDataContainer(nasa_banka, new AdminView()));
        }

        // GET: Nasa_banka/Create
        public ActionResult Create()
        {
            return View(new ViewDataContainer(null, new AdminView()));
        }

        // POST: Nasa_banka/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Broj_racunaNB,Stanje_racuna,Poslednja_uplata")] Nasa_banka nasa_banka)
        {
            if (ModelState.IsValid)
            {
                db.Nasa_banka.Add(nasa_banka);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(new ViewDataContainer(nasa_banka, new AdminView()));
        }

        // GET: Nasa_banka/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nasa_banka nasa_banka = db.Nasa_banka.Find(id);
            if (nasa_banka == null)
            {
                return HttpNotFound();
            }
            return View(new ViewDataContainer(nasa_banka, new AdminView()));
        }

        // POST: Nasa_banka/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Broj_racunaNB,Stanje_racuna,Poslednja_uplata")] Nasa_banka nasa_banka)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nasa_banka).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(new ViewDataContainer(nasa_banka, new AdminView()));
        }

        // GET: Nasa_banka/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nasa_banka nasa_banka = db.Nasa_banka.Find(id);
            if (nasa_banka == null)
            {
                return HttpNotFound();
            }
            return View(new ViewDataContainer(nasa_banka, new AdminView()));
        }

        // POST: Nasa_banka/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Nasa_banka nasa_banka = db.Nasa_banka.Find(id);
            db.Nasa_banka.Remove(nasa_banka);
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
