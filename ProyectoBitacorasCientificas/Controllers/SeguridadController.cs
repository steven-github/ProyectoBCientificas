using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using ProyectoBitacorasCientificas.Models;
using ProyectoBitacorasCientificas.ViewModels;

namespace ProyectoBitacorasCientificas.Controllers
{
    public class SeguridadController : Controller
    {
        private ApplicationDbContext _context;

        public SeguridadController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Seguridad
        public ActionResult Index()
        {
            return View();
        }


        #region Bitacoras Registro

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

        #endregion

        #region UsersCRUD 


        [Authorize(Roles = RoleName.CanManageAdministration + "," + RoleName.CanManageSecurity)]
        public ActionResult Usuarios()
        {
            return View();
        }
        #endregion

        #region RolesLaboratorio

        [Authorize(Roles = RoleName.CanManageAdministration + "," + RoleName.CanManageSecurity)]
        public ActionResult RolesLaboratorioCrear()
        {
            var labList = _context.Labs.ToList();
            var userList = _context.Users.ToList();

            var viewModel = new RolesLaboratorioForm()
            {
                Labs = labList, 
                ApplicationUsers = userList

            };

            return View("RolesLaboratorioForm", viewModel); 
        }

        [Authorize(Roles = RoleName.CanManageAdministration + "," + RoleName.CanManageSecurity)]
        public ActionResult RolesLaboratorioCrearEditar(RolesLaboratorio rolesLaboratorio)
        {
            var descripcion = "";
            if (rolesLaboratorio.id == 0)
            {
                _context.RolesLaboratorio.Add(rolesLaboratorio);
                descripcion = BitacoraRegistroEnum.rolLaboratorio + BitacoraRegistroEnum.create;
            }
            else
            {
                var rolInDb = _context.RolesLaboratorio.Single(c => c.id == rolesLaboratorio.id);

                rolInDb.LabsId = rolesLaboratorio.LabsId; 
                rolInDb.puesto = rolesLaboratorio.puesto; 
                rolInDb.tipoRol = rolesLaboratorio.tipoRol;

                descripcion = BitacoraRegistroEnum.stringEditDelete(
                   BitacoraRegistroEnum.rolLaboratorio,
                   rolInDb.id,
                   BitacoraRegistroEnum.edit
               );
            }

            _context.SaveChanges();
            BitacorasRegistroCrear(descripcion, BitacoraRegistroEnum.rolLaboratorio);
            return RedirectToAction("RolesLaboratorios", "Seguridad"); 

        }

        public ActionResult RolesLaboratorios()
        {
            if (User.IsInRole(RoleName.CanManageAdministration) || User.IsInRole(RoleName.CanManageSecurity))
            {
                var rolesList = _context.RolesLaboratorio
                    .Include(c => c.Labs)
                    .Include(c => c.ApplicationUser)
                    .ToList();
                return View(rolesList);
            }
            else
            {
                return View("RestrictedAccess");
            }
        }

        public ActionResult RolesLaboratorioEditar(int id)
        {
            var rol = _context.RolesLaboratorio.SingleOrDefault(c => c.id == id);
            if (rol == null)
                return HttpNotFound();

            var viewModel = new RolesLaboratorioForm()
            {
                RolesLaboratorio = rol,
                Labs = _context.Labs.ToList(),
                ApplicationUsers = _context.Users.ToList()
            };

            return View("RolesLaboratorioForm", viewModel);
        }

        public ActionResult RolesLaboratorioEliminar(int id)
        {
            var rol = _context.RolesLaboratorio.SingleOrDefault(c => c.id == id);
            _context.RolesLaboratorio.Remove(rol);
            _context.SaveChanges();

            var descripcion = BitacoraRegistroEnum.stringEditDelete(
                   BitacoraRegistroEnum.rolLaboratorio,
                   id,
                   BitacoraRegistroEnum.delete
              );
            BitacorasRegistroCrear(descripcion, BitacoraRegistroEnum.rolLaboratorio);
            return RedirectToAction("RolesLaboratorios", "Seguridad");
        }

        #endregion

        //#endregion
        // GET: Seguridad/RolesLaboratorioAsignar

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