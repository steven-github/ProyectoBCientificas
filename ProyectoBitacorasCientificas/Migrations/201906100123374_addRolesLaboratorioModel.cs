namespace ProyectoBitacorasCientificas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addRolesLaboratorioModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RolesLaboratorioModels",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nombre = c.String(),
                        descripcion = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.RolesLaboratorioModels");
        }
    }
}
