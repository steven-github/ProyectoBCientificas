using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoBitacorasCientificas.Models
{
    public class RolesLaboratorio
    {
        public int id { get; set; }

        public Labs Labs { get; set; }
        public int LabsId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
        public int ApplicationUserId { get; set; }

        public string tipoRol { get; set; }
        public string puesto { get; set; }

    }
}