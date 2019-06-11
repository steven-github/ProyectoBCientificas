using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations.Model;
using System.Linq;
using System.Web;

namespace ProyectoBitacorasCientificas.Models
{
    public class Objetivos
    {
        public int id { get; set; }
        public string objetivoGeneral { get; set; }
        public string objetivosEspecificos { get; set; }
        public string descripcion { get; set; }
        public string procedimientoExperimiento { get; set; }
        public Equipo Equipo { get; set; }
        public int EquipoId { get; set; }
    }
}