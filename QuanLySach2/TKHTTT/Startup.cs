using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TKHTTT.Startup))]
namespace TKHTTT
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
