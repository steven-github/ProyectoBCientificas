using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoBitacorasCientificas.Models;

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
        [Authorize(Roles = RoleName.CanManageAdministration + "," + RoleName.CanManageConsulting)]
        public ActionResult Bitacoras()
        {
            return View();
        }
        // GET: Consulta/Errores
        [Authorize(Roles = RoleName.CanManageAdministration + "," + RoleName.CanManageConsulting)]
        public ActionResult Errores()
        {
            return View();
        }
        // GET: Consulta/Descargas
        [Authorize(Roles = RoleName.CanManageAdministration + "," + RoleName.CanManageConsulting)]
        public ActionResult Descargas()
        {
            return View();
        }
    }
}