using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProyectoBitacorasCientificas.Models;

namespace ProyectoBitacorasCientificas.ViewModels
{
    public class ObjetivosForm
    {
        public IEnumerable<Bitacora> Bitacoras { get; set; }
        public IEnumerable<Equipo> Equipos { get; set; }
        public Objetivos Objetivos { get; set; }
    }
}