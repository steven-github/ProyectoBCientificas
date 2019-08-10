using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoBitacorasCientificas.Models;

namespace ProyectoBitacorasCientificas.Controllers
{
    public class ClientController : Controller
    {
        private ApplicationDbContext _context;

        public ClientController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Client
        public ActionResult Index()
        {
            if (User.IsInRole(RoleName.CanManageClientSide))
            {
                return View(); 
            }
            else
            {
                return View("RestrictedAccess"); 
            }
        }


    }
}