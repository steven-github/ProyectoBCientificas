using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoBitacorasCientificas.Models
{
    public class Bitacora
    {
        public int id { get; set; }
        public string prefijo { get; set; }
        public string nombreExperimento { get; set; }
        public string Fecha { get; set; }
        public string precio { get; set; }

        public Proyectos Proyectos { get; set; }
        public int ProyectosId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
        public int ApplicationUserId { get; set; }
    }
}