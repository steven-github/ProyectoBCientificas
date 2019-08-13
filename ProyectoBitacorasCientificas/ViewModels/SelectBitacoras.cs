using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProyectoBitacorasCientificas.Models;

namespace ProyectoBitacorasCientificas.ViewModels
{
    public class SelectBitacoras
    {
        public IEnumerable<Bitacora> Bitacoras { get; set; }
        public Bitacora Bitacora { get; set; }
    }
}