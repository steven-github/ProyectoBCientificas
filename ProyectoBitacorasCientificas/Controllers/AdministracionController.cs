using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoBitacorasCientificas.Controllers
{
    public class AdministracionController : Controller
    {
        // GET: Administracion
        public ActionResult Index()
        {
            return View();
        }
        // GET: Administracion/RamasCientificas
        public ActionResult RamasCientificas()
        {
            return View();
        }
        // GET: Administracion/Proyectos
        public ActionResult Proyectos()
        {
            return View();
        }
        // GET: Administracion/BitacorasCientificas
        public ActionResult BitacorasCientificas()
        {
            return View();
        }
    }
}