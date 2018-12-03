using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MaintainMe.WebMVC.Startup))]
namespace MaintainMe.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
