namespace ProyectoBitacorasCientificas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class anotherUselessMigration : DbMigration
    {
        public override void Up()
        {
            //DropForeignKey("dbo.BitacoraExperimentals", "ApplicationUser_Id", "dbo.AspNetUsers");
            //DropForeignKey("dbo.BitacoraExperimentals", "ObjetivosId", "dbo.Objetivos");
            //DropForeignKey("dbo.BitacoraExperimentals", "Proyectos_id", "dbo.Proyectos");
            //DropForeignKey("dbo.Puestoes", "ApplicationUser_Id", "dbo.AspNetUsers");
            //DropForeignKey("dbo.Puestoes", "LaboratorioId", "dbo.Laboratorios");
            //DropIndex("dbo.BitacoraExperimentals", new[] { "ObjetivosId" });
            //DropIndex("dbo.BitacoraExperimentals", new[] { "ApplicationUser_Id" });
            //DropIndex("dbo.BitacoraExperimentals", new[] { "Proyectos_id" });
            //DropIndex("dbo.Puestoes", new[] { "LaboratorioId" });
            //DropIndex("dbo.Puestoes", new[] { "ApplicationUser_Id" });
            //CreateTable(
            //    "dbo.BitacoraRegistroes",
            //    c => new
            //        {
            //            id = c.Int(nullable: false, identity: true),
            //            descripcion = c.String(),
            //            entidadRelacionada = c.String(),
            //        })
            //    .PrimaryKey(t => t.id);
            
            //CreateTable(
            //    "dbo.Bitacoras",
            //    c => new
            //        {
            //            id = c.Int(nullable: false, identity: true),
            //            prefijo = c.String(),
            //            nombreExperimento = c.String(),
            //            Fecha = c.String(),
            //            ProyectosId = c.Int(nullable: false),
            //            ApplicationUserId = c.Int(nullable: false),
            //            ApplicationUser_Id = c.String(maxLength: 128),
            //        })
            //    .PrimaryKey(t => t.id)
            //    .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
            //    .ForeignKey("dbo.Proyectos", t => t.ProyectosId, cascadeDelete: true)
            //    .Index(t => t.ProyectosId)
            //    .Index(t => t.ApplicationUser_Id);
            
            //CreateTable(
            //    "dbo.Labs",
            //    c => new
            //        {
            //            id = c.Int(nullable: false, identity: true),
            //            nombre = c.String(),
            //        })
            //    .PrimaryKey(t => t.id);
            
            //CreateTable(
            //    "dbo.RoleLabTipoes",
            //    c => new
            //        {
            //            id = c.Int(nullable: false, identity: true),
            //            nombre = c.String(),
            //        })
            //    .PrimaryKey(t => t.id);
            
            //AddColumn("dbo.Objetivos", "BitacoraId", c => c.Int(nullable: false));
            //AddColumn("dbo.RolesLaboratorios", "LabsId", c => c.Int(nullable: false));
            //AddColumn("dbo.RolesLaboratorios", "ApplicationUserId", c => c.Int(nullable: false));
            //AddColumn("dbo.RolesLaboratorios", "tipoRol", c => c.String());
            //AddColumn("dbo.RolesLaboratorios", "puesto", c => c.String());
            //AlterColumn("dbo.AspNetUsers", "nombre", c => c.String(nullable: false));
            //AlterColumn("dbo.AspNetUsers", "primerApellido", c => c.String(nullable: false));
            //AlterColumn("dbo.AspNetUsers", "segundoApellido", c => c.String(nullable: false));
            //AlterColumn("dbo.AspNetUsers", "nickname", c => c.String(nullable: false));
            //CreateIndex("dbo.Objetivos", "BitacoraId");
            //CreateIndex("dbo.RolesLaboratorios", "LabsId");
            //AddForeignKey("dbo.Objetivos", "BitacoraId", "dbo.Bitacoras", "id", cascadeDelete: true);
            //AddForeignKey("dbo.RolesLaboratorios", "LabsId", "dbo.Labs", "id", cascadeDelete: true);
            //DropColumn("dbo.Laboratorios", "lugar");
            //DropColumn("dbo.Puestoes", "LaboratorioId");
            //DropColumn("dbo.Puestoes", "userId");
            //DropColumn("dbo.Puestoes", "ApplicationUser_Id");
            //DropColumn("dbo.RolesLaboratorios", "nombre");
            //DropColumn("dbo.RolesLaboratorios", "descripcion");
            //DropColumn("dbo.RolesLaboratorios", "userId");
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
            
            AddColumn("dbo.RolesLaboratorios", "userId", c => c.Int(nullable: false));
            AddColumn("dbo.RolesLaboratorios", "descripcion", c => c.String());
            AddColumn("dbo.RolesLaboratorios", "nombre", c => c.String());
            AddColumn("dbo.Puestoes", "ApplicationUser_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Puestoes", "userId", c => c.Int(nullable: false));
            AddColumn("dbo.Puestoes", "LaboratorioId", c => c.Int(nullable: false));
            AddColumn("dbo.Laboratorios", "lugar", c => c.String());
            DropForeignKey("dbo.RolesLaboratorios", "LabsId", "dbo.Labs");
            DropForeignKey("dbo.Objetivos", "BitacoraId", "dbo.Bitacoras");
            DropForeignKey("dbo.Bitacoras", "ProyectosId", "dbo.Proyectos");
            DropForeignKey("dbo.Bitacoras", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.RolesLaboratorios", new[] { "LabsId" });
            DropIndex("dbo.Objetivos", new[] { "BitacoraId" });
            DropIndex("dbo.Bitacoras", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Bitacoras", new[] { "ProyectosId" });
            AlterColumn("dbo.AspNetUsers", "nickname", c => c.String());
            AlterColumn("dbo.AspNetUsers", "segundoApellido", c => c.String());
            AlterColumn("dbo.AspNetUsers", "primerApellido", c => c.String());
            AlterColumn("dbo.AspNetUsers", "nombre", c => c.String());
            DropColumn("dbo.RolesLaboratorios", "puesto");
            DropColumn("dbo.RolesLaboratorios", "tipoRol");
            DropColumn("dbo.RolesLaboratorios", "ApplicationUserId");
            DropColumn("dbo.RolesLaboratorios", "LabsId");
            DropColumn("dbo.Objetivos", "BitacoraId");
            DropTable("dbo.RoleLabTipoes");
            DropTable("dbo.Labs");
            DropTable("dbo.Bitacoras");
            DropTable("dbo.BitacoraRegistroes");
            CreateIndex("dbo.Puestoes", "ApplicationUser_Id");
            CreateIndex("dbo.Puestoes", "LaboratorioId");
            CreateIndex("dbo.BitacoraExperimentals", "Proyectos_id");
            CreateIndex("dbo.BitacoraExperimentals", "ApplicationUser_Id");
            CreateIndex("dbo.BitacoraExperimentals", "ObjetivosId");
            AddForeignKey("dbo.Puestoes", "LaboratorioId", "dbo.Laboratorios", "id", cascadeDelete: true);
            AddForeignKey("dbo.Puestoes", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.BitacoraExperimentals", "Proyectos_id", "dbo.Proyectos", "id");
            AddForeignKey("dbo.BitacoraExperimentals", "ObjetivosId", "dbo.Objetivos", "id", cascadeDelete: true);
            AddForeignKey("dbo.BitacoraExperimentals", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
