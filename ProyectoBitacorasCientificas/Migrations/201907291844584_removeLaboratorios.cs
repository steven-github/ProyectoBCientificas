namespace ProyectoBitacorasCientificas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeLaboratorios : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RolesLaboratorios", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.RolesLaboratorios", "LaboratorioId", "dbo.Laboratorios");
            DropForeignKey("dbo.RolesLaboratorios", "PuestoId", "dbo.Puestoes");
            DropForeignKey("dbo.RolesLaboratorios", "TipoRolLaboratorioId", "dbo.TipoRolLaboratorios");
            DropIndex("dbo.RolesLaboratorios", new[] { "LaboratorioId" });
            DropIndex("dbo.RolesLaboratorios", new[] { "TipoRolLaboratorioId" });
            DropIndex("dbo.RolesLaboratorios", new[] { "PuestoId" });
            DropIndex("dbo.RolesLaboratorios", new[] { "ApplicationUser_Id" });
            
            DropTable("dbo.RolesLaboratorios");
            DropTable("dbo.TipoRolLaboratorios");
            DropTable("dbo.Laboratorios");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.TipoRolLaboratorios",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nombre = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.RolesLaboratorios",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        ApplicationUserId = c.Int(nullable: false),
                        LaboratorioId = c.Int(nullable: false),
                        TipoRolLaboratorioId = c.Int(nullable: false),
                        PuestoId = c.Int(nullable: false),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Laboratorios",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nombre = c.String(),
                        lugar = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateIndex("dbo.RolesLaboratorios", "ApplicationUser_Id");
            CreateIndex("dbo.RolesLaboratorios", "PuestoId");
            CreateIndex("dbo.RolesLaboratorios", "TipoRolLaboratorioId");
            CreateIndex("dbo.RolesLaboratorios", "LaboratorioId");
            AddForeignKey("dbo.RolesLaboratorios", "TipoRolLaboratorioId", "dbo.TipoRolLaboratorios", "id", cascadeDelete: true);
            AddForeignKey("dbo.RolesLaboratorios", "PuestoId", "dbo.Puestoes", "id", cascadeDelete: true);
            AddForeignKey("dbo.RolesLaboratorios", "LaboratorioId", "dbo.Laboratorios", "id", cascadeDelete: true);
            AddForeignKey("dbo.RolesLaboratorios", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
