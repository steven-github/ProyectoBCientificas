using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoBitacorasCientificas.Controllers
{
    public class SeguridadController : Controller
    {
        // GET: Seguridad
        public ActionResult Index()
        {
            return View();
        }
        // GET: Seguridad/CrearUsuario
        public ActionResult CrearUsuario()
        {
            return View();
        }
        // GET: Seguridad/RolesUsuario
        public ActionResult RolesUsuario()
        {
            return View();
        }
        // GET: Seguridad/RolesLaboratorio
        public ActionResult RolesLaboratorio()
        {
            return View();
        }
        // GET: Seguridad/PuestosRoles
        public ActionResult PuestosRoles()
        {
            return View();
        }
        // GET: Seguridad/Consecutivos
        public ActionResult Consecutivos()
        {
            return View();
        }
        // GET: Seguridad/ConsecutivosCrear
        public ActionResult ConsecutivosCrear()
        {
            return View();
        }
        // GET: Seguridad/ConsecutivosEditar
        public ActionResult ConsecutivosEditar()
        {
            return View();
        }
    }
}