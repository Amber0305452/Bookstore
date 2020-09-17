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
            System.Data.Entity.Core.Objects.ObjectResult<sp_searchlanguage_Result> rows = db.sp_searchlanguage();
            if (option == "LangMag")
            {
                return View(rows.Where(m => m.Language_Magazine.Contains(search)));
            }
            if (option == "LangBook")
            {
                return View(rows.Where(m => m.Language_book.Contains(search)));
            }
            else
            {
                return View(rows.ToList());
            }
            
        }
    }
}