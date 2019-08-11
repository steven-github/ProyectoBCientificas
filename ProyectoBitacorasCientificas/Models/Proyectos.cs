using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoBitacorasCientificas.Models
{
    public class Proyectos
    {
        public int id { get; set; }
        public string prefijo { get; set; }
        public string nombre { get; set; }
        public RamaCientifica RamaCientifica { get; set; }
        public int RamaCientificaId { get; set; }
        }
}