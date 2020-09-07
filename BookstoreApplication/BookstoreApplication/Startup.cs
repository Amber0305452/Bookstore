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
        }
    }
}
