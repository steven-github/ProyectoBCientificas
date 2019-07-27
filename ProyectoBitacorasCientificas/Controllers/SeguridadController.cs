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

        #region UsersCRUD 
        

        [Authorize(Roles = RoleName.CanManageAdministration + "," + RoleName.CanManageSecurity)]
        public ActionResult Usuarios()
        {
            return View();
        }
        #endregion


        // GET: Seguridad/RolesUsuario
        [Authorize(Roles = RoleName.CanManageAdministration)]
        public ActionResult RolesUsuario(RolesUsuario rolesUsuario)
        {
            var usersList = _context.Users.ToList(); 
            var rolesList = _context.Roles.ToList();

            var viewModel = new UserRoleViewModel()
            {
                ApplicationUsers = usersList,
                IdentityRoles = rolesList
            };
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(_context));
            //UserManager.AddToRole(rolesUsuario.ApplicationUserId.ToString(), rolesUsuario.IdentityRoleId.ToString());
            return View("RolesUsuario",viewModel);
        }

        #region RolesUsuario

        public ActionResult RolesLaboratorioCrear()
        {
            var userList = _context.Users.ToList();
            var labList = _context.Laboratorios.ToList();
            var tipoRolList = _context.TipoRolLaboratorio.ToList();
            var puestosList = _context.Puestos.ToList();

            var viewModel = new RolLabForm()
            {
                Users = userList,
                Laboratorios = labList,
                TipoRolLaboratorios = tipoRolList,
                Puestos = puestosList
            };

            return View("RolesLaboratorioAsignar", viewModel); 
        }

        [HttpPost]
        [Authorize(Roles = RoleName.CanManageAdministration + "," + RoleName.CanManageConsecutives)]
        public ActionResult RolesLaboratorioAsignar(RolesLaboratorio rolLaboratorio)
        {
            if (rolLaboratorio.id == 0)
            {
                _context.RolesLaboratorio.Add(rolLaboratorio);
            }
            else
            {
                var rolInDb = _context.RolesLaboratorio.Single(c => c.id == rolLaboratorio.id);
                rolInDb.LaboratorioId = rolLaboratorio.LaboratorioId; 
            }
            _context.SaveChanges();
            return RedirectToAction("RolesUsuario", "Seguridad"); 
        }

        public ActionResult RolesLaboratorios()
        {
            if (User.IsInRole(RoleName.CanManageAdministration) || User.IsInRole(RoleName.CanManageSecurity))
            {
                var rolesList = _context.RolesLaboratorio
                    .Include(c => c.Laboratorio)
                    .Include(c => c.ApplicationUser)
                    .Include(c => c.TipoRolLaboratorio)
                    .Include(c => c.Puesto)
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

            var viewModel = new RolLabForm()
            {
                RolesLaboratorio = rol,
                Laboratorios = _context.Laboratorios.ToList(),
                Users = _context.Users.ToList(), 
                TipoRolLaboratorios = _context.TipoRolLaboratorio.ToList(), 
                Puestos = _context.Puestos.ToList()
            };

            return View("RolesLaboratorioAsignar", viewModel); 
        }

        public ActionResult RolesLaboratorioEliminar(int id)
        {
            var rol = _context.RolesLaboratorio.SingleOrDefault(c => c.id == id);
            _context.RolesLaboratorio.Remove(rol);
            _context.SaveChanges();
            return RedirectToAction("RolesLaboratorios", "Seguridad"); 
        }


        #endregion
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