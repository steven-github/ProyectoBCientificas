using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoBitacorasCientificas.Models
{
    public class Puesto
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public Laboratorio Laboratorio { get; set; }
        public int LaboratorioId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public int  userId { get; set; }
    }
}