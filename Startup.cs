using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(parking.Startup))]
namespace parking
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
