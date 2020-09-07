using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BookstoreApplication.Models;

namespace BookstoreApplication.Controllers
{
    public class MagazineController : Controller
    {
        private bookstoreEntities db = new bookstoreEntities();

        // GET: Magazine
        public ActionResult Index()
        {
            return View(db.Magazines.ToList());
        }

        // GET: Magazine/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Magazines magazines = db.Magazines.Find(id);
            if (magazines == null)
            {
                return HttpNotFound();
            }
            return View(magazines);
        }

        // GET: Magazine/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Magazine/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Magazineid,Title,Author,Publisher,PublishDate,Dimensions,ISSN,Cover")] Magazines magazines)
        {
            if (ModelState.IsValid)
            {
                db.Magazines.Add(magazines);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(magazines);
        }

        // GET: Magazine/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Magazines magazines = db.Magazines.Find(id);
            if (magazines == null)
            {
                return HttpNotFound();
            }
            return View(magazines);
        }

        // POST: Magazine/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Magazineid,Title,Author,Publisher,PublishDate,Dimensions,ISSN,Cover")] Magazines magazines)
        {
            if (ModelState.IsValid)
            {
                db.Entry(magazines).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(magazines);
        }

        // GET: Magazine/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Magazines magazines = db.Magazines.Find(id);
            if (magazines == null)
            {
                return HttpNotFound();
            }
            return View(magazines);
        }

        // POST: Magazine/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Magazines magazines = db.Magazines.Find(id);
            db.Magazines.Remove(magazines);
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
