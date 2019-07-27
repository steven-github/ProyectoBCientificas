namespace ProyectoBitacorasCientificas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NormalizingDbContext : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.RolesLabs", newName: "RolesLaboratorios");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.RolesLaboratorios", newName: "RolesLabs");
        }
    }
}
