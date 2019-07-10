using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProyectoBitacorasCientificas.Models;

namespace ProyectoBitacorasCientificas.ViewModels
{
    public class RamaCientificaForm
    {
        public IEnumerable<TipoRamaCientifica> TipoRamaCientificas { get; set; }
        public RamaCientifica RamaCientifica { get; set; }
    }
}