using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProyectoBitacorasCientificas.Models;

namespace ProyectoBitacorasCientificas.ViewModels
{
    public class BitacorasForm
    {
        public IEnumerable<Proyectos> Proyectos { get; set; }
        public IEnumerable<ApplicationUser> Users { get; set; }
        public Bitacora Bitacora { get; set; }
    }
}