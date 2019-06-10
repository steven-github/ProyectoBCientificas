namespace ProyectoBitacorasCientificas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedRolesLaboratorio : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.RolesLaboratorioModels", newName: "RolesLaboratorios");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.RolesLaboratorios", newName: "RolesLaboratorioModels");
        }
    }
}
