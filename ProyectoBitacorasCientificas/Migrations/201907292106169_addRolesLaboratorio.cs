namespace ProyectoBitacorasCientificas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addRolesLaboratorio : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RolesLaboratorios",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        LaboratorioId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Laboratorios", t => t.LaboratorioId, cascadeDelete: true)
                .Index(t => t.LaboratorioId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RolesLaboratorios", "LaboratorioId", "dbo.Laboratorios");
            DropIndex("dbo.RolesLaboratorios", new[] { "LaboratorioId" });
            DropTable("dbo.RolesLaboratorios");
        }
    }
}
