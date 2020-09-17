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
    [Authorize]
    public class MagazinesController : Controller
    {
        private bookstoreEntities db = new bookstoreEntities();
        [AllowAnonymous]
        // GET: Magazines
        public ActionResult Index(string option, string search)
        {
            IQueryable<Magazines> magazines = db.Magazines.Include(m => m.Authors).Include(m => m.Publishers);
            if (option == "Title")
            {
                return View(magazines.Where(m => m.Title.Contains(search) || search == null).ToList());
            }
            if (option == "ISSN")
            {
                return View(magazines.Where(m => m.ISSN.Contains(search) || search == null).ToList());
            }
            else
            {
                return View(magazines.ToList());
            }
        }

        // GET: Magazines/Details/5
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

        // GET: Magazines/Create
        public ActionResult Create()
        {
            ViewBag.Authorid = new SelectList(db.Authors, "Authorid", "FirstName");
            ViewBag.Publisherid = new SelectList(db.Publishers, "Publisherid", "FullName");
            return View();
        }

        // POST: Magazines/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Magazineid,Title,Authorid,Publisherid,Publishdate,Languages,Dimensions,ISSN,Cover")] Magazines magazines)
        {
            if (ModelState.IsValid)
            {
                db.Magazines.Add(magazines);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Authorid = new SelectList(db.Authors, "Authorid", "FirstName", magazines.Authorid);
            ViewBag.Publisherid = new SelectList(db.Publishers, "Publisherid", "FullName", magazines.Publisherid);
            return View(magazines);
        }

        // GET: Magazines/Edit/5
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
            ViewBag.Authorid = new SelectList(db.Authors, "Authorid", "FirstName", magazines.Authorid);
            ViewBag.Publisherid = new SelectList(db.Publishers, "Publisherid", "FullName", magazines.Publisherid);
            return View(magazines);
        }

        // POST: Magazines/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Magazineid,Title,Authorid,Publisherid,Publishdate,Languages,Dimensions,ISSN,Cover")] Magazines magazines)
        {
            if (ModelState.IsValid)
            {
                db.Entry(magazines).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Authorid = new SelectList(db.Authors, "Authorid", "FirstName", magazines.Authorid);
            ViewBag.Publisherid = new SelectList(db.Publishers, "Publisherid", "FullName", magazines.Publisherid);
            return View(magazines);
        }

        // GET: Magazines/Delete/5
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

        // POST: Magazines/Delete/5
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
