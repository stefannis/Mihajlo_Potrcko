﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Mihajlo_Potrcko.Components;
using Mihajlo_Potrcko.Connection;
using Mihajlo_Potrcko.LayoutViews;
using Mihajlo_Potrcko.Models;
using EntityState = System.Data.Entity.EntityState;

namespace Mihajlo_Potrcko.Controllers
{
    public class ReklamacijaController : Controller
    {
        private Potrcko db = new Potrcko();

        // GET: Reklamacija
        public ActionResult Index()
        {
            var reklamacija = db.Reklamacija.Include(r => r.Racun);
            return View(new ViewDataContainer(reklamacija.ToList(), new AdminView()));
        }

        // GET: Reklamacija/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reklamacija reklamacija = db.Reklamacija.Find(id);
            if (reklamacija == null)
            {
                return HttpNotFound();
            }
            return View(new ViewDataContainer(reklamacija, new AdminView()));
        }

        // GET: Reklamacija/Create
        public ActionResult Create()
        {
            ViewBag.FK_RacunID  = new SelectList(db.Racun, "RacunID", "Adresa");
            return View(new ViewDataContainer(null, new AdminView()));
        }
        // POST: Reklamacija/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ReklamacijaID,RacunID,Opis")] Reklamacija reklamacija)
        {
            if (ModelState.IsValid)
            {
                db.Reklamacija.Add(reklamacija);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FK_RacunID = new SelectList(db.Racun, "RacunID", "Adresa", reklamacija.RacunID);
            return View(new ViewDataContainer(reklamacija, new AdminView()));
        }

        // GET: Reklamacija/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reklamacija reklamacija = db.Reklamacija.Find(id);
            if (reklamacija == null)
            {
                return HttpNotFound();
            }
            ViewBag.FK_RacunID = new SelectList(db.Racun, "RacunID", "Adresa", reklamacija.RacunID);
            return View(new ViewDataContainer(reklamacija, new AdminView()));
        }

        // POST: Reklamacija/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ReklamacijaID,RacunID,Opis")] Reklamacija reklamacija)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reklamacija).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FK_RacunID = new SelectList(db.Racun, "RacunID", "Adresa", reklamacija.RacunID);
            return View(new ViewDataContainer(reklamacija, new AdminView()));
        }

        // GET: Reklamacija/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reklamacija reklamacija = db.Reklamacija.Find(id);
            if (reklamacija == null)
            {
                return HttpNotFound();
            }
            return View(new ViewDataContainer(reklamacija, new AdminView()));
        }

        // POST: Reklamacija/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Reklamacija reklamacija = db.Reklamacija.Find(id);
            db.Reklamacija.Remove(reklamacija);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        
        public ActionResult novaReklamacija(int racunID)
        {
            return View(new ViewDataContainer(racunID, new MainView()));
        }

        public ActionResult addReklamaciju(string racunID, string opis)
        {
            if (racunID != null)
            {
                int idRacuna = int.Parse(racunID);
                try
                {
                    string sql =
                        "INSERT INTO Reklamacija (FK_RacunID, Opis) VALUES(@param1, @param2)"; 

                    SqlCommand cmd = new SqlCommand(sql, Konekcija.PKonekcija);
                    cmd.Parameters.Add("@param1", SqlDbType.Int).Value = idRacuna;
                    cmd.Parameters.Add("@param2", SqlDbType.VarChar, 256).Value = opis;
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                }
            }
            
            return RedirectToAction("Index", "Home");
        }
        //public ActionResult addReklamaciju(int racunID, string opis)
        //{
        //    Reklamacija reklamacija = new Reklamacija() {};
        //}
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
