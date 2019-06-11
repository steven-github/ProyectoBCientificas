using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoBitacorasCientificas.Models
{
    public class RamaCientifica
    {
        public int id { get; set; }
        public string prefijo { get; set; }
        public string nombre { get; set; }
        public TipoRamaCientifica TipoRamaCientifica { get; set; }
        public int TipoRamaCientificaId { get; set; }


    }
}