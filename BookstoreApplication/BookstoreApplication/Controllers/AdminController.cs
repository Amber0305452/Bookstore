using BookstoreApplication.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookstoreApplication.Controllers
{
    //used https://www.youtube.com/watch?v=TdDAyRiLBFA
    [Authorize(Roles ="SuperAdmin")]
    /*
     * accountsuper admin is: 
     * Email: I9A@gmail.com
     * Password: Hallo12.
     */
    public class AdminController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CreateUser()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateUser(FormCollection form)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            string UserName = form["txtEmail"];
            string email = form["txtEmail"];
            string pwd = form["txtPassword"];

            //create user
            ApplicationUser user = new ApplicationUser();
            user.UserName = UserName;
            user.Email = email;

            IdentityResult newuser = userManager.Create(user, pwd);

            return View();
        }
        
        public ActionResult CreateRole()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewRole(FormCollection form)
        {
            string rolename = form["RoleName"];
            RoleManager<IdentityRole> roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            if (!roleManager.RoleExists(rolename))
            {
                IdentityRole role = new IdentityRole(rolename);
                roleManager.Create(role);
            }
            return View("Index");
        }

        public ActionResult AssignRole()
        {
            List<SelectListItem> list = context.Roles.Select(r => new SelectListItem { Value = r.Name, Text = r.Name }).ToList();
            ViewBag.Roles = list;
            return View(list);
        }
        [HttpPost]
        public ActionResult AssignRole(FormCollection form)
        {
            string username = form["txtUserName"];
            string rolname = form["RoleName"];
            ApplicationUser user = context.Users.Where(u => u.UserName.Equals(username, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
            UserManager<ApplicationUser> userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            userManager.AddToRole(user.Id, rolname);
            return View("Index");
        }
    }
}