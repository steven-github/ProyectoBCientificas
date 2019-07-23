using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoBitacorasCientificas.Models;
using ProyectoBitacorasCientificas.ViewModels;

namespace ProyectoBitacorasCientificas.Controllers
{
    public class AdministracionController : Controller
    {
        private ApplicationDbContext _context;

        public AdministracionController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Administracion
        public ActionResult Index()
        {
            return View();
        }

        #region RamasCientificasCRUD

        // GET: Administracion/RamasCientificasForm
        [Authorize(Roles = RoleName.CanManageAdministration + "," + RoleName.CanManageMantenimiento)]
        public ActionResult RamasCientificasForm()
        {
            var tiposRamas = _context.TipoRamaCientifica.ToList();

            var viewModel = new RamaCientificaForm()
            {
                TipoRamaCientificas = tiposRamas
            };


            return View("RamasCientificasForm", viewModel);

        }

        // GET: Administracion/RamasCientificas
        public ActionResult RamasCientificas()
        {
            if (User.IsInRole(RoleName.CanManageAdministration) || User.IsInRole(RoleName.CanManageMantenimiento))
            {
                var ramasList = _context.RamaCientifica.Include(c => c.TipoRamaCientifica).ToList();
                return View(ramasList);
            }
            else
            {
                return View("RestrictedAccess");
            }
        }


        [HttpPost]
         [Authorize(Roles = RoleName.CanManageAdministration + "," + RoleName.CanManageMantenimiento)]
        public ActionResult RamaCientificasCrearEditar(RamaCientifica ramaCientifica)
        {
            if (ramaCientifica.id == 0)
            {
                _context.RamaCientifica.Add(ramaCientifica);
            }
            else
            {
                var ramaCientificaInDb = _context.RamaCientifica.Single(c => c.id == ramaCientifica.id);

                ramaCientificaInDb.prefijo = ramaCientifica.prefijo;
                ramaCientificaInDb.nombre = ramaCientifica.nombre;
                ramaCientificaInDb.TipoRamaCientificaId = ramaCientifica.TipoRamaCientificaId;

            }

            _context.SaveChanges();
            return RedirectToAction("RamasCientificas", "Administracion");
        }

        // GET: Administracion/RamasCientificasEditar
         [Authorize(Roles = RoleName.CanManageAdministration + "," + RoleName.CanManageMantenimiento)]
        public ActionResult RamasCientificasEditar(int id)
        {
            var ramaCientifica = _context.RamaCientifica.SingleOrDefault(c => c.id == id);
            if (ramaCientifica == null)
            {
                return HttpNotFound();
            }

            var viewModel = new RamaCientificaForm()
            {
                RamaCientifica = ramaCientifica,
                TipoRamaCientificas = _context.TipoRamaCientifica.ToList()
            };

            return View("RamasCientificasForm", viewModel);
        }

         [Authorize(Roles = RoleName.CanManageAdministration + "," + RoleName.CanManageMantenimiento)]
        public ActionResult RamasCientificasEliminar(int id)
        {
            var ramaCientifica = _context.RamaCientifica.SingleOrDefault(c => c.id == id);
            _context.RamaCientifica.Remove(ramaCientifica);
            _context.SaveChanges();
            return RedirectToAction("RamasCientificas", "Administracion");
        }

        #endregion

        #region ProyectosCRUD

         [Authorize(Roles = RoleName.CanManageAdministration + "," + RoleName.CanManageMantenimiento)]
        public ActionResult ProyectosForm()
        {
            var ramasList = _context.RamaCientifica.ToList();

            var viewModel = new ProyectoRamaCientificaForm()
            {
                RamasCientificas = ramasList
            };


            return View("ProyectosForm", viewModel);
        }

        public ActionResult Proyectos()
        {
            if (User.IsInRole(RoleName.CanManageAdministration) || User.IsInRole(RoleName.CanManageMantenimiento))
            {
                var proyectosList = _context.Proyectos.Include(c => c.RamaCientifica).ToList();
                return View(proyectosList);
            }
            else
            {
                return View("RestrictedAccess");
            }

        }

        [HttpPost]
        [Authorize(Roles = RoleName.CanManageAdministration + "," + RoleName.CanManageMantenimiento)]
        public ActionResult ProyectosCrearEditar(Proyectos proyectos)
        {
            if (proyectos.id == 0)
            {
                _context.Proyectos.Add(proyectos); 
            }
            else
            {
                var proyectoInDb = _context.Proyectos.Single(c => c.id == proyectos.id);

                proyectoInDb.prefijo = proyectos.prefijo;
                proyectoInDb.nombre = proyectos.nombre;
                proyectoInDb.RamaCientificaId = proyectos.RamaCientificaId;
            }

            _context.SaveChanges();
            return RedirectToAction("Proyectos", "Administracion");
        }

        // GET: Administracion/ProyectosEditar
         [Authorize(Roles = RoleName.CanManageAdministration + "," + RoleName.CanManageMantenimiento)]
        public ActionResult ProyectosEditar(int id)
        {

            var proyecto = _context.Proyectos.SingleOrDefault(c => c.id == id);
            if (proyecto == null)
            {
                return HttpNotFound();
            }

            var viewModel = new ProyectoRamaCientificaForm()
            {
                Proyectos = proyecto,
                RamasCientificas = _context.RamaCientifica.ToList()
            };

            return View("ProyectosForm", viewModel);
        }

         [Authorize(Roles = RoleName.CanManageAdministration + "," + RoleName.CanManageMantenimiento)]
        public ActionResult ProyectosEliminar(int id)
        {
            var proyecto = _context.Proyectos.SingleOrDefault(c => c.id == id);
            _context.Proyectos.Remove(proyecto);
            _context.SaveChanges();
            return RedirectToAction("Proyectos", "Administracion");
        }
        #endregion

        #region BitacorasCRUD

        // GET: Administracion/BitacorasCientificasCrear
        [Authorize(Roles = RoleName.CanManageAdministration + "," + RoleName.CanManageMantenimiento)]
        public ActionResult BitacorasCientificasCrear()
        {
            var proyectosList = _context.Proyectos.ToList();

            var viewModel = new BitacorasForm()
            {
                Proyectos = proyectosList
            };

            return View("BitacorasCientificasForm",viewModel);
        }

        [Authorize(Roles = RoleName.CanManageAdministration + "," + RoleName.CanManageMantenimiento)]
        public ActionResult BitacorasCrearEditar(Bitacora bitacora)
        {
            if (bitacora.id == 0)
            {
                _context.Bitacoras.Add(bitacora);
            }
            else
            {
                var bitacoraInDb = _context.Bitacoras.Single(c => c.id == bitacora.id);

                bitacoraInDb.nombreExperimento = bitacora.nombreExperimento;
                bitacoraInDb.prefijo = bitacora.prefijo;
                bitacoraInDb.Fecha = bitacora.Fecha;
                bitacoraInDb.ProyectosId = bitacora.ProyectosId;
            }

            _context.SaveChanges();

            return RedirectToAction("BitacorasCientificas", "Administracion");
        }

        //GET: Administracion/BitacorasCientificas
        public ActionResult BitacorasCientificas()
        {
            if (User.IsInRole(RoleName.CanManageAdministration) || User.IsInRole(RoleName.CanManageMantenimiento))
            {
                var bitacorasList = _context.Bitacoras
                    .Include(c => c.Proyectos)
                    .ToList();

                return View(bitacorasList);
            }
            else
            {
                return View("RestrictedAccess");
            }
               
        }

        // GET: Administracion/BitacorasCientificasEditar
        [Authorize(Roles = RoleName.CanManageAdministration + "," + RoleName.CanManageMantenimiento)]
        public ActionResult BitacorasCientificasEditar(int id)
        {
            var bitacora = _context.Bitacoras.SingleOrDefault(c => c.id == id);
            if (bitacora == null)
                return HttpNotFound();

            var viewModel = new BitacorasForm()
            {
                Bitacora = bitacora,
                Proyectos = _context.Proyectos.ToList()
            };

            return View("BitacorasCientificasForm",viewModel);
        }

        [Authorize(Roles = RoleName.CanManageAdministration + "," + RoleName.CanManageMantenimiento)]
        public ActionResult BitacorasEliminar(int id)
        {
            var bitacora = _context.Bitacoras.SingleOrDefault(c => c.id == id);
            _context.Bitacoras.Remove(bitacora);
            _context.SaveChanges();
            return RedirectToAction("BitacorasCientificas", "Administracion");
        }


        #endregion

        #region ObjetivosCRUD

         [Authorize(Roles = RoleName.CanManageAdministration + "," + RoleName.CanManageMantenimiento)]
        public ActionResult ObjetivosCrear()
        {
            var bitacorasList = _context.Bitacoras.ToList();
            var equiposList = _context.Equipo.ToList();

            var viewModel = new ObjetivosForm()
            {
                Bitacoras = bitacorasList, 
                Equipos = equiposList
            };

            return View("ObjetivosForm", viewModel);
        }

        public ActionResult Objetivos()
        {
            if (User.IsInRole(RoleName.CanManageAdministration) || User.IsInRole(RoleName.CanManageMantenimiento))
            {
                var objetivos = _context.Objetivos
                    .Include(c => c.Bitacora)
                    .Include(c => c.Equipo)
                    .ToList();

                return View(objetivos);
            }
            else
            {
                return View("RestrictedAccess"); 
            }
            
        }

         [Authorize(Roles = RoleName.CanManageAdministration + "," + RoleName.CanManageMantenimiento)]
        public ActionResult ObjetivosCrearEditar(Objetivos objetivos)
        {
            if (objetivos.id == 0)
            {
                _context.Objetivos.Add(objetivos);
            }
            else
            {
                var objetivoInDb = _context.Objetivos.Single(c => c.id == objetivos.id);
                objetivoInDb.objetivoGeneral = objetivos.objetivoGeneral; 
                objetivoInDb.objetivosEspecificos = objetivos.objetivosEspecificos; 
                objetivoInDb.descripcion = objetivos.descripcion; 
                objetivoInDb.procedimientoExperimiento = objetivos.procedimientoExperimiento; 
                objetivoInDb.BitacoraId = objetivos.BitacoraId; 
                objetivoInDb.EquipoId = objetivos.EquipoId; 

            }

            _context.SaveChanges();

            return RedirectToAction("Objetivos", "Administracion"); 
        }

         [Authorize(Roles = RoleName.CanManageAdministration + "," + RoleName.CanManageMantenimiento)]
        public ActionResult ObjetivosEditar(int id)
        {
            var objetivo = _context.Objetivos.SingleOrDefault(c => c.id == id);
            if (objetivo == null)
                return HttpNotFound();

            var viewModel = new ObjetivosForm()
            {
                Objetivos = objetivo,
                Bitacoras = _context.Bitacoras.ToList(),
                Equipos = _context.Equipo.ToList()
            };

            return View("ObjetivosForm", viewModel);
        }

         [Authorize(Roles = RoleName.CanManageAdministration + "," + RoleName.CanManageMantenimiento)]
        public ActionResult ObjetivosEliminar(int id)
        {
            var objetivo = _context.Objetivos.SingleOrDefault(c => c.id == id);
            _context.Objetivos.Remove(objetivo);
            _context.SaveChanges();
            return RedirectToAction("Objetivos", "Administracion");
        }

        #endregion



    }
}