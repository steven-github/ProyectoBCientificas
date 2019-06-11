namespace ProyectoBitacorasCientificas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddModelsForLabRelated : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BitacoraExperimentals",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        prefijo = c.String(),
                        nombreExperimento = c.String(),
                        fecha = c.DateTime(nullable: false),
                        ProyectoId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        ObjetivosId = c.Int(nullable: false),
                        ApplicationUser_Id = c.String(maxLength: 128),
                        Proyectos_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .ForeignKey("dbo.Objetivos", t => t.ObjetivosId, cascadeDelete: true)
                .ForeignKey("dbo.Proyectos", t => t.Proyectos_id)
                .Index(t => t.ObjetivosId)
                .Index(t => t.ApplicationUser_Id)
                .Index(t => t.Proyectos_id);
            
            CreateTable(
                "dbo.Objetivos",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        objetivoGeneral = c.String(),
                        objetivosEspecificos = c.String(),
                        descripcion = c.String(),
                        procedimientoExperimiento = c.String(),
                        EquipoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Equipoes", t => t.EquipoId, cascadeDelete: true)
                .Index(t => t.EquipoId);
            
            CreateTable(
                "dbo.Equipoes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        marca = c.String(),
                        modelo = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Proyectos",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        prefijo = c.String(),
                        nombre = c.String(),
                        RamaCientificaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.RamaCientificas", t => t.RamaCientificaId, cascadeDelete: true)
                .Index(t => t.RamaCientificaId);
            
            CreateTable(
                "dbo.RamaCientificas",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        prefijo = c.String(),
                        nombre = c.String(),
                        TipoRamaCientificaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.TipoRamaCientificas", t => t.TipoRamaCientificaId, cascadeDelete: true)
                .Index(t => t.TipoRamaCientificaId);
            
            CreateTable(
                "dbo.TipoRamaCientificas",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nombre = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BitacoraExperimentals", "Proyectos_id", "dbo.Proyectos");
            DropForeignKey("dbo.Proyectos", "RamaCientificaId", "dbo.RamaCientificas");
            DropForeignKey("dbo.RamaCientificas", "TipoRamaCientificaId", "dbo.TipoRamaCientificas");
            DropForeignKey("dbo.BitacoraExperimentals", "ObjetivosId", "dbo.Objetivos");
            DropForeignKey("dbo.Objetivos", "EquipoId", "dbo.Equipoes");
            DropForeignKey("dbo.BitacoraExperimentals", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.RamaCientificas", new[] { "TipoRamaCientificaId" });
            DropIndex("dbo.Proyectos", new[] { "RamaCientificaId" });
            DropIndex("dbo.Objetivos", new[] { "EquipoId" });
            DropIndex("dbo.BitacoraExperimentals", new[] { "Proyectos_id" });
            DropIndex("dbo.BitacoraExperimentals", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.BitacoraExperimentals", new[] { "ObjetivosId" });
            DropTable("dbo.TipoRamaCientificas");
            DropTable("dbo.RamaCientificas");
            DropTable("dbo.Proyectos");
            DropTable("dbo.Equipoes");
            DropTable("dbo.Objetivos");
            DropTable("dbo.BitacoraExperimentals");
        }
    }
}
