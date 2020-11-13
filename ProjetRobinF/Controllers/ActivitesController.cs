﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjetRobinF.Models;
using ProjetRobinF.dal;

namespace ProjetRobinF.Controllers
{
    public class ActivitesController : Controller
    {
        private ProjetContext db = new ProjetContext();

        // GET: Activites
        public ActionResult Index()
        {
            var activites = db.Activites.Include(a => a.Ville);
            return View(activites.ToList());
        }

        // GET: Activites/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Activite activite = db.Activites.Find(id);
            if (activite == null)
            {
                return HttpNotFound();
            }
            return View(activite);
        }

        // GET: Activites/Create
        public ActionResult Create()
        {
            ViewBag.VilleID = new SelectList(db.Villes, "ID", "Nom");
            return View();
        }

        // POST: Activites/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_A,Nom,Addresse,Description,VilleID")] Activite activite)
        {
            if (ModelState.IsValid)
            {
                db.Activites.Add(activite);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.VilleID = new SelectList(db.Villes, "ID", "Nom", activite.VilleID);
            return View(activite);
        }

        // GET: Activites/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Activite activite = db.Activites.Find(id);
            if (activite == null)
            {
                return HttpNotFound();
            }
            ViewBag.VilleID = new SelectList(db.Villes, "ID", "Nom", activite.VilleID);
            return View(activite);
        }

        // POST: Activites/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_A,Nom,Addresse,Description,VilleID")] Activite activite)
        {
            if (ModelState.IsValid)
            {
                db.Entry(activite).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.VilleID = new SelectList(db.Villes, "ID", "Nom", activite.VilleID);
            return View(activite);
        }

        // GET: Activites/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Activite activite = db.Activites.Find(id);
            if (activite == null)
            {
                return HttpNotFound();
            }
            return View(activite);
        }

        // POST: Activites/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Activite activite = db.Activites.Find(id);
            db.Activites.Remove(activite);
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
