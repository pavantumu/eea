using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EEAFormI9Portal.Startup))]
namespace EEAFormI9Portal
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
