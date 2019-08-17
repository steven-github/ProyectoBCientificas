using ProyectoBitacorasCientificas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoBitacorasCientificas.ViewModels
{
    public class CompraCompletadaViewModel
    {
        public Factura FacturaFinal { get; set; }
        public Bitacora BitacoraComprada { get; set; }
    }
}