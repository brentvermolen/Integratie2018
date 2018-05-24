using System.Globalization;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace MVCIntegratie
{
   public class FilterConfig
   {
      public static void RegisterGlobalFilters(GlobalFilterCollection filters)
      {
         filters.Add(new HandleErrorAttribute());
         filters.Add(new LangFilterAttribute());
        }
   }
       public class LangFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Session["CurrentLang"] == null)
            {
                //default en-US
                filterContext.HttpContext.Session["CurrentLang"] = "en-US";
            }
            //change current cultureinfo every time
            Thread.CurrentThread.CurrentCulture = new CultureInfo(filterContext.HttpContext.Session["CurrentLang"].ToString());
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(filterContext.HttpContext.Session["CurrentLang"].ToString());
            base.OnActionExecuting(filterContext);
        }
    }
}
