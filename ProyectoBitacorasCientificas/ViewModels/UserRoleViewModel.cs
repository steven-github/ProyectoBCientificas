using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;
using ProyectoBitacorasCientificas.Models;

namespace ProyectoBitacorasCientificas.ViewModels
{
    public class UserRoleViewModel
    {
        public IEnumerable<IdentityRole> IdentityRoles { get; set; }
        public IEnumerable<ApplicationUser> ApplicationUsers { get; set; }
        public RolesUsuario RolesUsuario { get; set; }
    }
}