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

         Process.Start("C:\\Users\\natha\\Desktop\\Git_IntegratieProject\\CA\\bin\\Debug\\CA.exe");
      }
   }
}
