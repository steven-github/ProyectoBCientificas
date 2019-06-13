using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoBitacorasCientificas.Controllers
{
    public class ConsultaController : Controller
    {
        // GET: Consulta
        public ActionResult Index()
        {
            return View();
        }
        // GET: Consulta/Bitacora
        public ActionResult Bitacora()
        {
            return View();
        }
        // GET: Consulta/Errores
        public ActionResult Errores()
        {
            return View();
        }
        // GET: Consulta/Descargas
        public ActionResult Descargas()
        {
            return View();
        }
    }
}