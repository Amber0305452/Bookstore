using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookstoreApplication.Models;

namespace BookstoreApplication.Controllers
{
    public class LanguagesController : Controller
    {
        // GET: Languages
        public ActionResult Index(string search, string option)
        {
            bookstoreEntities db = new bookstoreEntities();
            var rows = db.sp_searchlanguage();
            if (option == "LangMag")
            {
                return View(rows.Where(m => m.Language_Magazine.Contains(search)).ToList());
            }
            if (option == "LangBook")
            {
                return View(rows.Where(m => m.Language_book.Contains(search)).ToList());
            }
            else
            {
                return View(rows.ToList());
            }
            
        }
    }
}