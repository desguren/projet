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
    public class HotelsController : Controller
    {
        private ProjetContext db = new ProjetContext();

        // GET: Hotels
        public ViewResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.EtoileSortParm = String.IsNullOrEmpty(sortOrder) ? "etoile" : "";
            ViewBag.PrixSortParm = String.IsNullOrEmpty(sortOrder) ? "prix" : "";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;
            var hotels = from s in db.Hotels
                         select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                hotels = hotels.Where(s => s.Nom.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    hotels = hotels.OrderByDescending(s => s.Nom);
                    break;
                case "etoile":
                    hotels = hotels.OrderBy(s => s.Etoile);
                    break;
                case "prix":
                    hotels = hotels.OrderBy(s => s.Prix);
                    break;
                default:
                    hotels = hotels.OrderBy(s => s.Nom);
                    break;
            }
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(hotels.ToPagedList(pageNumber, pageSize));


        }
    

        // GET: Hotels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hotel hotel = db.Hotels.Find(id);
            if (hotel == null)
            {
                return HttpNotFound();
            }
            return View(hotel);
        }

        // GET: Hotels/Create
        public ActionResult Create()
        {
            ViewBag.VilleID = new SelectList(db.Villes, "ID", "Nom");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_H,Nom,Etoile,Prix,VilleID")] Hotel hotel)
        {
            if (ModelState.IsValid)
            {
                db.Hotels.Add(hotel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.VilleID = new SelectList(db.Villes, "ID", "Nom", hotel.VilleID);
            return View(hotel);
        }

        // GET: Hotels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hotel hotel = db.Hotels.Find(id);
            if (hotel == null)
            {
                return HttpNotFound();
            }
            ViewBag.VilleID = new SelectList(db.Villes, "ID", "Nom", hotel.VilleID);
            return View(hotel);
        }

        // POST: Hotels/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_H,Nom,Etoile,Prix,VilleID")] Hotel hotel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hotel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.VilleID = new SelectList(db.Villes, "ID", "Nom", hotel.VilleID);
            return View(hotel);
        }

        // GET: Hotels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hotel hotel = db.Hotels.Find(id);
            if (hotel == null)
            {
                return HttpNotFound();
            }
            return View(hotel);
        }

        // POST: Hotels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Hotel hotel = db.Hotels.Find(id);
            db.Hotels.Remove(hotel);
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
