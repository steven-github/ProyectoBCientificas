using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoBitacorasCientificas.Models;

namespace ProyectoBitacorasCientificas.Controllers
{
    public class SeguridadController : Controller
    {
        // GET: Seguridad
        public ActionResult Index()
        {
            return View();
        }

        #region UsersCRUD 
        // GET: Seguridad/CrearUsuario
        [Authorize(Roles = RoleName.CanManageAdministration + "," + RoleName.CanManageSecurity)]
        public ActionResult CrearUsuario()
        {
            return View();
        }

        [Authorize(Roles = RoleName.CanManageAdministration + "," + RoleName.CanManageSecurity)]
        public ActionResult Usuarios()
        {
            return View();
        }
        #endregion


        // GET: Seguridad/RolesUsuario
        [Authorize(Roles = RoleName.CanManageAdministration)]
        public ActionResult RolesUsuario()
        {
            return View();
        }
        // GET: Seguridad/RolesLaboratorio
        [Authorize(Roles = RoleName.CanManageAdministration)]
        public ActionResult RolesLaboratorio()
        {
            return View();
        }
        // GET: Seguridad/PuestosRoles
        [Authorize(Roles = RoleName.CanManageAdministration)]
        public ActionResult PuestosRoles()
        {
            return View();
        }
        // GET: Seguridad/Consecutivos
        [Authorize(Roles = RoleName.CanManageAdministration + "," + RoleName.CanManageConsecutives)]
        public ActionResult Consecutivos()
        {
            return View();
        }
        // GET: Seguridad/ConsecutivosCrear
        [Authorize(Roles = RoleName.CanManageAdministration + "," + RoleName.CanManageConsecutives)]
        public ActionResult ConsecutivosCrear()
        {
            return View();
        }
        // GET: Seguridad/ConsecutivosEditar
        [Authorize(Roles = RoleName.CanManageAdministration + "," + RoleName.CanManageConsecutives)]
        public ActionResult ConsecutivosEditar()
        {
            return View();
        }
    }
}