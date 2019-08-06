using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProyectoBitacorasCientificas.Models;

namespace ProyectoBitacorasCientificas.ViewModels
{
    public class RolesLaboratorioForm
    {
        public IEnumerable<Labs> Labs { get; set; }
        public IEnumerable<ApplicationUser> ApplicationUsers { get; set; }
        public RolesLaboratorio RolesLaboratorio { get; set; }
    }
}