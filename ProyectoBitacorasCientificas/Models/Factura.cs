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

        public Bitacora Bitacora { get; set; }
        public int BitacoraId { get; set; }

    }
}