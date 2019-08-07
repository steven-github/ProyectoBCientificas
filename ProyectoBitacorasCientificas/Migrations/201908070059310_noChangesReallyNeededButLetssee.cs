namespace ProyectoBitacorasCientificas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class noChangesReallyNeededButLetssee : DbMigration
    {
        public override void Up()
        {
            //DropForeignKey("dbo.Bitacoras", "ApplicationUser_Id", "dbo.AspNetUsers");
            //DropForeignKey("dbo.Bitacoras", "ProyectosId", "dbo.Proyectos");
            //DropForeignKey("dbo.Objetivos", "BitacoraId", "dbo.Bitacoras");
            //DropForeignKey("dbo.RolesLaboratorios", "LabsId", "dbo.Labs");
            //DropIndex("dbo.Bitacoras", new[] { "ProyectosId" });
            //DropIndex("dbo.Bitacoras", new[] { "ApplicationUser_Id" });
            //DropIndex("dbo.Objetivos", new[] { "BitacoraId" });
            //DropIndex("dbo.RolesLaboratorios", new[] { "LabsId" });
            //CreateTable(
            //    "dbo.BitacoraExperimentals",
            //    c => new
            //        {
            //            id = c.Int(nullable: false, identity: true),
            //            prefijo = c.String(),
            //            nombreExperimento = c.String(),
            //            fecha = c.DateTime(nullable: false),
            //            ProyectoId = c.Int(nullable: false),
            //            UserId = c.Int(nullable: false),
            //            ObjetivosId = c.Int(nullable: false),
            //            ApplicationUser_Id = c.String(maxLength: 128),
            //            Proyectos_id = c.Int(),
            //        })
            //    .PrimaryKey(t => t.id)
            //    .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
            //    .ForeignKey("dbo.Objetivos", t => t.ObjetivosId, cascadeDelete: true)
            //    .ForeignKey("dbo.Proyectos", t => t.Proyectos_id)
            //    .Index(t => t.ObjetivosId)
            //    .Index(t => t.ApplicationUser_Id)
            //    .Index(t => t.Proyectos_id);
            
            //AddColumn("dbo.Laboratorios", "lugar", c => c.String());
            //AddColumn("dbo.Puestoes", "LaboratorioId", c => c.Int(nullable: false));
            //AddColumn("dbo.Puestoes", "userId", c => c.Int(nullable: false));
            //AddColumn("dbo.Puestoes", "ApplicationUser_Id", c => c.String(maxLength: 128));
            //AddColumn("dbo.RolesLaboratorios", "nombre", c => c.String());
            //AddColumn("dbo.RolesLaboratorios", "descripcion", c => c.String());
            //AddColumn("dbo.RolesLaboratorios", "userId", c => c.Int(nullable: false));
            //AlterColumn("dbo.AspNetUsers", "nombre", c => c.String());
            //AlterColumn("dbo.AspNetUsers", "primerApellido", c => c.String());
            //AlterColumn("dbo.AspNetUsers", "segundoApellido", c => c.String());
            //AlterColumn("dbo.AspNetUsers", "nickName", c => c.String());
            //CreateIndex("dbo.Puestoes", "LaboratorioId");
            //CreateIndex("dbo.Puestoes", "ApplicationUser_Id");
            //AddForeignKey("dbo.Puestoes", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
            //AddForeignKey("dbo.Puestoes", "LaboratorioId", "dbo.Laboratorios", "id", cascadeDelete: true);
            //DropColumn("dbo.Objetivos", "BitacoraId");
            //DropColumn("dbo.RolesLaboratorios", "LabsId");
            //DropColumn("dbo.RolesLaboratorios", "ApplicationUserId");
            //DropColumn("dbo.RolesLaboratorios", "tipoRol");
            //DropColumn("dbo.RolesLaboratorios", "puesto");
            //DropTable("dbo.BitacoraRegistroes");
            //DropTable("dbo.Bitacoras");
            //DropTable("dbo.Labs");
            //DropTable("dbo.RoleLabTipoes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.RoleLabTipoes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nombre = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Labs",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nombre = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Bitacoras",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        prefijo = c.String(),
                        nombreExperimento = c.String(),
                        Fecha = c.String(),
                        ProyectosId = c.Int(nullable: false),
                        ApplicationUserId = c.Int(nullable: false),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.BitacoraRegistroes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        descripcion = c.String(),
                        entidadRelacionada = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            AddColumn("dbo.RolesLaboratorios", "puesto", c => c.String());
            AddColumn("dbo.RolesLaboratorios", "tipoRol", c => c.String());
            AddColumn("dbo.RolesLaboratorios", "ApplicationUserId", c => c.Int(nullable: false));
            AddColumn("dbo.RolesLaboratorios", "LabsId", c => c.Int(nullable: false));
            AddColumn("dbo.Objetivos", "BitacoraId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Puestoes", "LaboratorioId", "dbo.Laboratorios");
            DropForeignKey("dbo.Puestoes", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.BitacoraExperimentals", "Proyectos_id", "dbo.Proyectos");
            DropForeignKey("dbo.BitacoraExperimentals", "ObjetivosId", "dbo.Objetivos");
            DropForeignKey("dbo.BitacoraExperimentals", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Puestoes", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Puestoes", new[] { "LaboratorioId" });
            DropIndex("dbo.BitacoraExperimentals", new[] { "Proyectos_id" });
            DropIndex("dbo.BitacoraExperimentals", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.BitacoraExperimentals", new[] { "ObjetivosId" });
            AlterColumn("dbo.AspNetUsers", "nickName", c => c.String(nullable: false));
            AlterColumn("dbo.AspNetUsers", "segundoApellido", c => c.String(nullable: false));
            AlterColumn("dbo.AspNetUsers", "primerApellido", c => c.String(nullable: false));
            AlterColumn("dbo.AspNetUsers", "nombre", c => c.String(nullable: false));
            DropColumn("dbo.RolesLaboratorios", "userId");
            DropColumn("dbo.RolesLaboratorios", "descripcion");
            DropColumn("dbo.RolesLaboratorios", "nombre");
            DropColumn("dbo.Puestoes", "ApplicationUser_Id");
            DropColumn("dbo.Puestoes", "userId");
            DropColumn("dbo.Puestoes", "LaboratorioId");
            DropColumn("dbo.Laboratorios", "lugar");
            DropTable("dbo.BitacoraExperimentals");
            CreateIndex("dbo.RolesLaboratorios", "LabsId");
            CreateIndex("dbo.Objetivos", "BitacoraId");
            CreateIndex("dbo.Bitacoras", "ApplicationUser_Id");
            CreateIndex("dbo.Bitacoras", "ProyectosId");
            AddForeignKey("dbo.RolesLaboratorios", "LabsId", "dbo.Labs", "id", cascadeDelete: true);
            AddForeignKey("dbo.Objetivos", "BitacoraId", "dbo.Bitacoras", "id", cascadeDelete: true);
            AddForeignKey("dbo.Bitacoras", "ProyectosId", "dbo.Proyectos", "id", cascadeDelete: true);
            AddForeignKey("dbo.Bitacoras", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
