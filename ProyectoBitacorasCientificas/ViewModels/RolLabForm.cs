using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProyectoBitacorasCientificas.Models;

namespace ProyectoBitacorasCientificas.ViewModels
{
    public class RolLabForm
    {
        public IEnumerable<Laboratorio> Laboratorios { get; set; }
        public IEnumerable<ApplicationUser> Users { get; set; }
        public IEnumerable<TipoRolLaboratorio> TipoRolLaboratorios { get; set; }
        public IEnumerable<Puesto> Puestos { get; set; }
        public RolesLaboratorio RolesLaboratorio { get; set; }
    }
}