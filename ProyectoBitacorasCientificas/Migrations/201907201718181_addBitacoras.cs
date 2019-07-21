namespace ProyectoBitacorasCientificas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addBitacoras : DbMigration
    {
        public override void Up()
        {
            //DropForeignKey("dbo.BitacoraExperimentals", "ApplicationUser_Id", "dbo.AspNetUsers");
            //DropForeignKey("dbo.BitacoraExperimentals", "ObjetivosId", "dbo.Objetivos");
            //DropForeignKey("dbo.BitacoraExperimentals", "Proyectos_id", "dbo.Proyectos");
            //DropIndex("dbo.BitacoraExperimentals", new[] { "ObjetivosId" });
            //DropIndex("dbo.BitacoraExperimentals", new[] { "ApplicationUser_Id" });
            //DropIndex("dbo.BitacoraExperimentals", new[] { "Proyectos_id" });
            ////CreateTable(
            //    "dbo.Bitacoras",
            //    c => new
            //        {
            //            id = c.Int(nullable: false, identity: true),
            //            prefijo = c.String(),
            //            nombreExperimento = c.String(),
            //            Fecha = c.String(),
            //            ProyectosId = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.id)
            //    .ForeignKey("dbo.Proyectos", t => t.ProyectosId, cascadeDelete: true)
            //    .Index(t => t.ProyectosId);
            
            //AddColumn("dbo.Objetivos", "BitacoraId", c => c.Int(nullable: false));
            //CreateIndex("dbo.Objetivos", "BitacoraId");
            //AddForeignKey("dbo.Objetivos", "BitacoraId", "dbo.Bitacoras", "id", cascadeDelete: true);
            //DropTable("dbo.BitacoraExperimentals");
        }
        
        public override void Down()
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
                .PrimaryKey(t => t.id);
            
            DropForeignKey("dbo.Objetivos", "BitacoraId", "dbo.Bitacoras");
            DropForeignKey("dbo.Bitacoras", "ProyectosId", "dbo.Proyectos");
            DropIndex("dbo.Objetivos", new[] { "BitacoraId" });
            DropIndex("dbo.Bitacoras", new[] { "ProyectosId" });
            DropColumn("dbo.Objetivos", "BitacoraId");
            DropTable("dbo.Bitacoras");
            CreateIndex("dbo.BitacoraExperimentals", "Proyectos_id");
            CreateIndex("dbo.BitacoraExperimentals", "ApplicationUser_Id");
            CreateIndex("dbo.BitacoraExperimentals", "ObjetivosId");
            AddForeignKey("dbo.BitacoraExperimentals", "Proyectos_id", "dbo.Proyectos", "id");
            AddForeignKey("dbo.BitacoraExperimentals", "ObjetivosId", "dbo.Objetivos", "id", cascadeDelete: true);
            AddForeignKey("dbo.BitacoraExperimentals", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
