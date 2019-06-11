using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoBitacorasCientificas.Models
{
    public class Tarjeta
    {
        public int id { get; set; }
        public string numTarjeta { get; set; }
        public string fechaExpiracion { get; set; }
        public int cvv { get; set; }
        public Factura Factura { get; set; }
        public int FacturaId { get; set; }
        public Transaccion Transaccion { get; set; }
        public int TransaccionId { get; set; }
    }
}