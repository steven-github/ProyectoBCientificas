using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.Migrations.Model;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ProyectoBitacorasCientificas.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        // Custom Properties 
        [Required]
        public string nombre { get; set; }
        [Required]
        public string primerApellido { get; set; }
        [Required]
        public string segundoApellido { get; set; }
        public string telefono { get; set; }
        [Required]
        public string nickname { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        //public DbSet<TipoRolLaboratorio> TipoRolLaboratorio { get; set; }
        public DbSet<NivelAcademico> NivelAcademicos { get; set; }
        public DbSet<Puesto> Puestos { get; set; }
        public DbSet<RamaCientifica> RamaCientifica { get; set; }
        public DbSet<TipoRamaCientifica> TipoRamaCientifica { get; set; }
        public DbSet<Proyectos> Proyectos { get; set; }
        public DbSet<Bitacora> Bitacoras { get; set; }
        public DbSet<Equipo> Equipo { get; set; }
        public DbSet<Objetivos> Objetivos { get; set; }
        public DbSet<Factura> Facturas { get; set; }
        public DbSet<BitacoraRegistro> BitacoraRegistros { get; set; }
        public DbSet<Laboratorio> Laboratorios { get; set; }
        public DbSet<Labs> Labs { get; set; }
        public DbSet<RolesLaboratorio> RolesLaboratorio { get; set; }
        public DbSet<RoleLabTipo> RoleLabTipos { get; set; }
        public DbSet<Error> Errors { get; set; }


    }
}