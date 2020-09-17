using BookstoreApplication.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BookstoreApplication.Startup))]
namespace BookstoreApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateUserAndRoles();
        }
        public void CreateUserAndRoles()
        {
            ApplicationDbContext context = new ApplicationDbContext();
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            if (!roleManager.RoleExists("SuperAdmin"))
            {
                //create superadmin role
                IdentityRole role = new IdentityRole("SuperAdmin");
                roleManager.Create(role);

                /*create default user
                 * It wouldn't add this user...no clue why
                ApplicationUser user = new ApplicationUser();
                user.UserName = "admin@gmail.com";
                user.Email = "admin@gmail.com";
                string pwd= "Password@2020";

                IdentityResult newuser = userManager.Create(user, pwd);
                if (newuser.Succeeded)
                {
                    userManager.AddToRole(user.Id, "SuperAdmin");
                }*/
            }


        }
    }
}
