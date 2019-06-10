namespace ProyectoBitacorasCientificas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createPuestoAndLaboratorio : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Laboratorios",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nombre = c.String(),
                        lugar = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Puestoes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nombre = c.String(),
                        LaboratorioId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Laboratorios", t => t.LaboratorioId, cascadeDelete: true)
                .Index(t => t.LaboratorioId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Puestoes", "LaboratorioId", "dbo.Laboratorios");
            DropIndex("dbo.Puestoes", new[] { "LaboratorioId" });
            DropTable("dbo.Puestoes");
            DropTable("dbo.Laboratorios");
        }
    }
}
