using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoBitacorasCientificas.Models
{
    public class NivelAcademico
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public int userId { get; set; }
    }
}