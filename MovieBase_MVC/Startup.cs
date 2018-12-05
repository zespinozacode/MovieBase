using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MovieBase_MVC.Startup))]
namespace MovieBase_MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
