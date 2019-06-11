using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoBitacorasCientificas.Models
{
    public class EasyPay
    {
        public int id { get; set; }
        public string cuenta { get; set; }
        public Factura Factura { get; set; }
        public int FacturaId { get; set; }
        public Transaccion Transaccion { get; set; }
        public int TransaccionId { get; set; }
    }
}