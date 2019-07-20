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
            var ramasList = _context.RamaCientifica.Include(c => c.TipoRamaCientifica).ToList();
            return View(ramasList);
        }


        [HttpPost]

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

        public ActionResult RamasCientificasEliminar(int id)
        {
            var ramaCientifica = _context.RamaCientifica.SingleOrDefault(c => c.id == id);
            _context.RamaCientifica.Remove(ramaCientifica);
            _context.SaveChanges();
            return RedirectToAction("RamasCientificas", "Administracion");
        }

        #endregion

        #region ProyectosCRUD

        
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
            var proyectosList = _context.Proyectos.Include(c => c.RamaCientifica).ToList();
            return View(proyectosList);
        }

        [HttpPost]
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
        public ActionResult BitacorasCientificasCrear()
        {
            var proyectosList = _context.Proyectos.ToList();

            var viewModel = new BitacorasForm()
            {
                Proyectos = proyectosList
            };

            return View("BitacorasCientificasForm",viewModel);
        }

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
            var bitacorasList = _context.Bitacoras
                .Include(c => c.Proyectos)
                .ToList();

            return View(bitacorasList);
        }
        
        // GET: Administracion/BitacorasCientificasEditar
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

        public ActionResult BitacorasEliminar(int id)
        {
            var bitacora = _context.Bitacoras.SingleOrDefault(c => c.id == id);
            _context.Bitacoras.Remove(bitacora);
            _context.SaveChanges();
            return RedirectToAction("BitacorasCientificas", "Administracion");
        }


        #endregion

    }
}