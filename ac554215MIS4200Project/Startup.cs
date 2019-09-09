using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ac554215MIS4200Project.Startup))]
namespace ac554215MIS4200Project
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
