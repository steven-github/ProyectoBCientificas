using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoBitacorasCientificas.Models
{
    public class RolesLaboratorio
    {
        public int id { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        public int ApplicationUserId { get; set; }
        public Laboratorio Laboratorio { get; set; }
        public int LaboratorioId { get; set; }
        public TipoRolLaboratorio TipoRolLaboratorio { get; set; }
        public int TipoRolLaboratorioId { get; set; }
        public Puesto Puesto { get; set; }
        public int PuestoId { get; set; }
    }
}