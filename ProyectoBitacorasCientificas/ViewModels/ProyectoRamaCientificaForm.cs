using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProyectoBitacorasCientificas.Models;

namespace ProyectoBitacorasCientificas.ViewModels
{
    public class ProyectoRamaCientificaForm
    {
        public IEnumerable<RamaCientifica> RamasCientificas { get; set; }
        public Proyectos Proyectos { get; set; }
    }
}