using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoBitacorasCientificas.Models
{
    public class BitacoraExperimental
    {
        public int id { get; set; }
        public string prefijo { get; set; }
        public string nombreExperimento { get; set; }
        public DateTime fecha { get; set; }
        public Proyectos Proyectos { get; set; }
        public int ProyectoId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public int UserId { get; set; }
        public Objetivos Objetivos { get; set; }
        public int ObjetivosId { get; set; }
        // TODO: Figure out how to match the Testigo with User Id ( Double FK? ) 
    }
}