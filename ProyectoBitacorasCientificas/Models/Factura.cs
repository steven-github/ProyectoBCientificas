using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoBitacorasCientificas.Models
{
    public class Factura
    {
        public int id { get; set; }
        public DateTime fechaEmision { get; set; }
        public double monto { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public int ClienteId { get; set; }

    }
}