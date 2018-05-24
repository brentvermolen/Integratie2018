using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCIntegratie.Startup))]
namespace MVCIntegratie
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
