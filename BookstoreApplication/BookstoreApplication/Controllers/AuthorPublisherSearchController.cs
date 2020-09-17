using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookstoreApplication.Models;

namespace BookstoreApplication.Controllers
{
    public class AuthorPublisherSearchController : Controller
    {
        // GET: AuthorPublisherSearch
        public ActionResult Index(string search, string option)
        {
            bookstoreEntities db = new bookstoreEntities();
            System.Data.Entity.Core.Objects.ObjectResult<sp_searchauthororpublisher1_Result> rows = db.sp_searchauthororpublisher1();
            if (option == "Author")
            {
                return View(rows.Where(m => m.Name_of_Author.Contains(search)).ToList());
            }
            if (option == "Publisher")
            {
                return View(rows.Where(m => m.Name_of_Publisher.Contains(search)).ToList());
            }
            else
            {
                return View(rows.ToList());
            }
            
        }
    }
}