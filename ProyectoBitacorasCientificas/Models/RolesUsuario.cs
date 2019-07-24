using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ProyectoBitacorasCientificas.Models
{
    public class RolesUsuario
    {
        public int id { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public int ApplicationUserId { get; set; }
        public IdentityRole IdentityRole { get; set; }
        public int IdentityRoleId { get; set; }
    }
}