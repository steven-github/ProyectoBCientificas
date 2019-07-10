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
        // GET: Administracion/RamasCientificasCrear
        public ActionResult RamasCientificasCrear()
        {
            var tiposRamas = _context.TipoRamaCientifica.ToList();

            var viewModel = new RamaCientificaForm()
            {
                TipoRamaCientificas = tiposRamas
            };

            return View("RamasCientificasCrear", viewModel);
        }

        // GET: Administracion/RamasCientificas
        public ActionResult RamasCientificas()
        {
            var ramasList = _context.RamaCientifica.Include(c => c.TipoRamaCientifica).ToList();
            return View(ramasList);
        }


        [HttpPost]
        public ActionResult CrearEditar(RamaCientifica ramaCientifica)
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

            return View("RamasCientificasCrear", viewModel);
        }

        public ActionResult RamasCientificasEliminar(int id)
        {
            var ramaCientifica = _context.RamaCientifica.SingleOrDefault(c => c.id == id);
            _context.RamaCientifica.Remove(ramaCientifica);
            _context.SaveChanges();
            return RedirectToAction("RamasCientificas", "Administracion");
        }

        #endregion


        // GET: Administracion/Proyectos
        public ActionResult Proyectos()
        {
            return View();
        }
        // GET: Administracion/ProyectosCrear
        public ActionResult ProyectosCrear()
        {
            return View();
        }
        // GET: Administracion/ProyectosEditar
        public ActionResult ProyectosEditar()
        {
            return View();
        }
        // GET: Administracion/BitacorasCientificas
        public ActionResult BitacorasCientificas()
        {
            return View();
        }
        // GET: Administracion/BitacorasCientificasCrear
        public ActionResult BitacorasCientificasCrear()
        {
            return View();
        }
        // GET: Administracion/BitacorasCientificasEditar
        public ActionResult BitacorasCientificasEditar()
        {
            return View();
        }
    }
}