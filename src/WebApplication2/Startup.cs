using Microsoft.Owin;
using Ninject.Web.Common.OwinHost;
using Owin;
using WebApplication2.Ioc;

[assembly: OwinStartupAttribute(typeof(WebApplication2.Startup))]
namespace WebApplication2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseNinjectMiddleware(() => DependencyResolver.Instance.Kernel);

            ConfigureAuth(app);
        }
    }
}
