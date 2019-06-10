using ProyectoBitacorasCientificas.Models;

namespace ProyectoBitacorasCientificas.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ProyectoBitacorasCientificas.Models.ApplicationDbContext>
    {
        public DbSet<RolesLaboratorio> RolesLaboratorioModel { get; set; }

        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ProyectoBitacorasCientificas.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
