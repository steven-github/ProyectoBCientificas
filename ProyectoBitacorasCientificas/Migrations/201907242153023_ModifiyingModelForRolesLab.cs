namespace ProyectoBitacorasCientificas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifiyingModelForRolesLab : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Puestoes", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Puestoes", "LaboratorioId", "dbo.Laboratorios");
            DropIndex("dbo.Puestoes", new[] { "LaboratorioId" });
            DropIndex("dbo.Puestoes", new[] { "ApplicationUser_Id" });
            CreateTable(
                "dbo.TipoRolLaboratorios",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nombre = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            AddColumn("dbo.RolesLaboratorios", "LaboratorioId", c => c.Int(nullable: false));
            AddColumn("dbo.RolesLaboratorios", "ApplicationUserId", c => c.Int(nullable: false));
            AddColumn("dbo.RolesLaboratorios", "TipoRolLaboratorioId", c => c.Int(nullable: false));
            AddColumn("dbo.RolesLaboratorios", "PuestoId", c => c.Int(nullable: false));
            CreateIndex("dbo.RolesLaboratorios", "LaboratorioId");
            CreateIndex("dbo.RolesLaboratorios", "TipoRolLaboratorioId");
            CreateIndex("dbo.RolesLaboratorios", "PuestoId");
            AddForeignKey("dbo.RolesLaboratorios", "LaboratorioId", "dbo.Laboratorios", "id", cascadeDelete: true);
            AddForeignKey("dbo.RolesLaboratorios", "PuestoId", "dbo.Puestoes", "id", cascadeDelete: true);
            AddForeignKey("dbo.RolesLaboratorios", "TipoRolLaboratorioId", "dbo.TipoRolLaboratorios", "id", cascadeDelete: true);
            DropColumn("dbo.Puestoes", "LaboratorioId");
            DropColumn("dbo.Puestoes", "userId");
            DropColumn("dbo.Puestoes", "ApplicationUser_Id");
            DropColumn("dbo.RolesLaboratorios", "nombre");
            DropColumn("dbo.RolesLaboratorios", "descripcion");
            DropColumn("dbo.RolesLaboratorios", "userId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RolesLaboratorios", "userId", c => c.Int(nullable: false));
            AddColumn("dbo.RolesLaboratorios", "descripcion", c => c.String());
            AddColumn("dbo.RolesLaboratorios", "nombre", c => c.String());
            AddColumn("dbo.Puestoes", "ApplicationUser_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Puestoes", "userId", c => c.Int(nullable: false));
            AddColumn("dbo.Puestoes", "LaboratorioId", c => c.Int(nullable: false));
            DropForeignKey("dbo.RolesLaboratorios", "TipoRolLaboratorioId", "dbo.TipoRolLaboratorios");
            DropForeignKey("dbo.RolesLaboratorios", "PuestoId", "dbo.Puestoes");
            DropForeignKey("dbo.RolesLaboratorios", "LaboratorioId", "dbo.Laboratorios");
            DropIndex("dbo.RolesLaboratorios", new[] { "PuestoId" });
            DropIndex("dbo.RolesLaboratorios", new[] { "TipoRolLaboratorioId" });
            DropIndex("dbo.RolesLaboratorios", new[] { "LaboratorioId" });
            DropColumn("dbo.RolesLaboratorios", "PuestoId");
            DropColumn("dbo.RolesLaboratorios", "TipoRolLaboratorioId");
            DropColumn("dbo.RolesLaboratorios", "ApplicationUserId");
            DropColumn("dbo.RolesLaboratorios", "LaboratorioId");
            DropTable("dbo.TipoRolLaboratorios");
            CreateIndex("dbo.Puestoes", "ApplicationUser_Id");
            CreateIndex("dbo.Puestoes", "LaboratorioId");
            AddForeignKey("dbo.Puestoes", "LaboratorioId", "dbo.Laboratorios", "id", cascadeDelete: true);
            AddForeignKey("dbo.Puestoes", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
