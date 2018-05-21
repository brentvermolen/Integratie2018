using Microsoft.Owin;
using Owin;
using System.Diagnostics;

[assembly: OwinStartupAttribute(typeof(MVCIntegratie.Startup))]
namespace MVCIntegratie
{
   public partial class Startup
   {
      public void Configuration(IAppBuilder app)
      {
         ConfigureAuth(app);

         Process.Start("C:\\Users\\Brent\\Documents\\School\\KDG\\2017-2018\\IntegratieProject\\MVCIntegratie\\CA\\bin\\Debug\\CA.exe");
      }
   }
}
