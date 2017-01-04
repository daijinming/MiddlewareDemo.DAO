using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MiddlewareDemo.DAO.Startup))]
namespace MiddlewareDemo.DAO
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.UseNancy();
        }
    }
}
