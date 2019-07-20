using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoBitacorasCientificas.Models
{
    public class CompraExperimento
    {
        public int id { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public int UserId { get; set; }
        //public BitacoraExperimental BitacoraExperimental { get; set; }
        //public int ExperimentoId { get; set; }
        public Transaccion Transaccion { get; set; }
        public int TransaccionId { get; set; }
    }
}