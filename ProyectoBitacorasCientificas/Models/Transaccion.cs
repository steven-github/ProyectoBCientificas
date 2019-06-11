using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoBitacorasCientificas.Models
{
    public class Transaccion
    {
        public int id { get; set; }
        public int tipoTranssacion { get; set; }
        public string refTipoTransaccion { get; set; }
    }
}