using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace ProyectoBitacorasCientificas.Controllers
{
    public class LanguageController : Controller
    {
        // GET: lANGUAGE
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Change(String LanguageAbbreviation)
        {
            if (LanguageAbbreviation != null)
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(LanguageAbbreviation);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(LanguageAbbreviation);
            }

            HttpCookie cookie = new HttpCookie("Language");
            cookie.Value = LanguageAbbreviation;
            Response.Cookies.Add(cookie);

            //string actionName = ControllerContext.RouteData.GetRequiredString("action");
            //string controllerName = ControllerContext.RouteData.GetRequiredString("controller");

            // grab action from RequestContext
            //string action = System.Web.HttpContext.Current.Request.RequestContext.RouteData.GetRequiredString("action");

            return RedirectToAction("Index", "Home");

            //return View("Index");

        }
    }
}