using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoBitacorasCientificas.Models;

namespace ProyectoBitacorasCientificas.Controllers
{
    public class RamasCientificasController : Controller
    {
        private ApplicationDbContext _context;

        public RamasCientificasController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose(); 
        }

        /*
         * public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new CustomerFormViewModel()
            {
                MembershipTypes = membershipTypes
            }; 
            return View("CustomerForm",viewModel); 
        }
         */

        public ActionResult New()
        {
            var ramasCientificas = _context.RamaCientifica.ToList();
            return View(ramasCientificas); 

        }

        
        public ActionResult RamasCientificas()
        {
            var ramasList = _context.RamaCientifica.Include(c => c.TipoRamaCientifica).ToList();
            return View(ramasList);
        }
    }
}