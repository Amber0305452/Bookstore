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
    public class BooksController : Controller
    {
        private bookstoreEntities db = new bookstoreEntities();

        // GET: Books
        public ActionResult Index(string search, string option)
        {
            var books = db.Books.Include(b => b.Authors).Include(b => b.Publishers);
            if (option == "Title")
            {
                return View(books.Where(m => m.Title.Contains(search) || search == null).ToList());
            }
            if (option == "ISBN")
            {
                return View(books.Where(m => m.ISBN.Equals(search) || search == null).ToList());
            }
            else
            {
                return View(books.ToList());
            }
       
        }

        // GET: Books/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Books books = db.Books.Find(id);
            if (books == null)
            {
                return HttpNotFound();
            }
            return View(books);
        }

        // GET: Books/Create
        public ActionResult Create()
        {
            ViewBag.Authorid = new SelectList(db.Authors, "Authorid", "FirstName");
            ViewBag.Publisherid = new SelectList(db.Publishers, "Publisherid", "FullName");
            return View();
        }

        // POST: Books/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Bookid,Title,Authorid,Publisherid,Languages,Dimensions,Weights,Prints,ISBN,Cover")] Books books)
        {
            if (ModelState.IsValid)
            {
                db.Books.Add(books);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Authorid = new SelectList(db.Authors, "Authorid", "FirstName", books.Authorid);
            ViewBag.Publisherid = new SelectList(db.Publishers, "Publisherid", "FullName", books.Publisherid);
            return View(books);
        }

        // GET: Books/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Books books = db.Books.Find(id);
            if (books == null)
            {
                return HttpNotFound();
            }
            ViewBag.Authorid = new SelectList(db.Authors, "Authorid", "FirstName", books.Authorid);
            ViewBag.Publisherid = new SelectList(db.Publishers, "Publisherid", "FullName", books.Publisherid);
            return View(books);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Bookid,Title,Authorid,Publisherid,Languages,Dimensions,Weights,Prints,ISBN,Cover")] Books books)
        {
            if (ModelState.IsValid)
            {
                db.Entry(books).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Authorid = new SelectList(db.Authors, "Authorid", "FirstName", books.Authorid);
            ViewBag.Publisherid = new SelectList(db.Publishers, "Publisherid", "FullName", books.Publisherid);
            return View(books);
        }

        // GET: Books/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Books books = db.Books.Find(id);
            if (books == null)
            {
                return HttpNotFound();
            }
            return View(books);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Books books = db.Books.Find(id);
            db.Books.Remove(books);
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
