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

        private ApplicationDbContext _context;

        public ConsultaController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Consulta
        public ActionResult Index()
        {
            return View();
        }

        #region BitacoraRegistro

        public ActionResult BitacorasRegistroCrear(
            string descripcion, string entidadRelacionada
        )
        {
            var bitacoraRegistro = new BitacoraRegistro
            {
                descripcion = descripcion,
                entidadRelacionada = entidadRelacionada
            };
            _context.BitacoraRegistros.Add(bitacoraRegistro);
            _context.SaveChanges();
            return new EmptyResult(); 
        }

            // GET: Consulta/Bitacora
        public ActionResult Bitacoras()
        {
            if (User.IsInRole(RoleName.CanManageAdministration) || User.IsInRole(RoleName.CanManageConsulting))
            {
                var bitacorasRegistro = _context.BitacoraRegistros.ToList();
                return View(bitacorasRegistro);
            }
            else
            {
                return View("RestrictedAccess");
            }
        }


        #endregion

        // GET: Consulta/Errores
        [Authorize(Roles = RoleName.CanManageAdministration + "," + RoleName.CanManageConsulting)]
        public ActionResult Errores()
        {
            if (User.IsInRole(RoleName.CanManageAdministration) || User.IsInRole(RoleName.CanManageConsulting))
            {
                var errores = _context.Errors.ToList();
                return View(errores);
            }
            else
            {
                return View("RestrictedAccess");
            }
        }

        // GET: Consulta/Descargas
        [Authorize(Roles = RoleName.CanManageAdministration + "," + RoleName.CanManageConsulting)]
        public ActionResult Descargas()
        {
            return View();
        }
    }
}