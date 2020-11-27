using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjetRobinF.Models;
using ProjetRobinF.dal;
using PagedList;

namespace ProjetRobinF.Controllers
{
    public class VillesController : Controller
    {
        private ProjetContext db = new ProjetContext();

        // GET: Villes
        public ViewResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.RegionSortParm = String.IsNullOrEmpty(sortOrder) ? "region" : "";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;
            var villes = from s in db.Villes
                           select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                villes = villes.Where(s => s.Nom.Contains(searchString));
            }
            switch (sortOrder) 
            {
                case "name_desc":
                    villes = villes.OrderByDescending(s => s.Nom);
                    break;
                case "region":
                    villes = villes.OrderBy(s => s.Region);
                    break;
                default:  
                    villes = villes.OrderBy(s => s.Nom);
                    break;
            }
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(villes.ToPagedList(pageNumber, pageSize));
        }

        // GET: Villes/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ville ville = db.Villes.Find(id);
            if (ville == null)
            {
                return HttpNotFound();
            }
            return View(ville);
        }

        // GET: Villes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Villes/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nom,Region")] Ville ville)
        {
            if (ModelState.IsValid)
            {
                db.Villes.Add(ville);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ville);
        }

        // GET: Villes/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ville ville = db.Villes.Find(id);
            if (ville == null)
            {
                return HttpNotFound();
            }
            return View(ville);
        }

        // POST: Villes/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nom,Region")] Ville ville)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ville).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ville);
        }

        // GET: Villes/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ville ville = db.Villes.Find(id);
            if (ville == null)
            {
                return HttpNotFound();
            }
            return View(ville);
        }

        // POST: Villes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Ville ville = db.Villes.Find(id);
            db.Villes.Remove(ville);
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
