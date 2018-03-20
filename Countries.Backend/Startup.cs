using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Countries.Backend.Startup))]
namespace Countries.Backend
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
