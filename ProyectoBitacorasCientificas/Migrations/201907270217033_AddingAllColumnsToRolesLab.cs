namespace ProyectoBitacorasCientificas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingAllColumnsToRolesLab : DbMigration
    {
        public override void Up()
        {
            //AddColumn("dbo.RolesLaboratorios", "ApplicationUserId", c => c.Int(nullable: false));
            //AddColumn("dbo.RolesLaboratorios", "TipoRolLaboratorioId", c => c.Int(nullable: false));
            //AddColumn("dbo.RolesLaboratorios", "PuestoId", c => c.Int(nullable: false));
            //AddColumn("dbo.RolesLaboratorios", "ApplicationUser_Id", c => c.String(maxLength: 128));
            //CreateIndex("dbo.RolesLaboratorios", "TipoRolLaboratorioId");
            //CreateIndex("dbo.RolesLaboratorios", "PuestoId");
            //CreateIndex("dbo.RolesLaboratorios", "ApplicationUser_Id");
            //AddForeignKey("dbo.RolesLaboratorios", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
            //AddForeignKey("dbo.RolesLaboratorios", "PuestoId", "dbo.Puestoes", "id", cascadeDelete: true);
            //AddForeignKey("dbo.RolesLaboratorios", "TipoRolLaboratorioId", "dbo.TipoRolLaboratorios", "id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RolesLaboratorios", "TipoRolLaboratorioId", "dbo.TipoRolLaboratorios");
            DropForeignKey("dbo.RolesLaboratorios", "PuestoId", "dbo.Puestoes");
            DropForeignKey("dbo.RolesLaboratorios", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.RolesLaboratorios", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.RolesLaboratorios", new[] { "PuestoId" });
            DropIndex("dbo.RolesLaboratorios", new[] { "TipoRolLaboratorioId" });
            DropColumn("dbo.RolesLaboratorios", "ApplicationUser_Id");
            DropColumn("dbo.RolesLaboratorios", "PuestoId");
            DropColumn("dbo.RolesLaboratorios", "TipoRolLaboratorioId");
            DropColumn("dbo.RolesLaboratorios", "ApplicationUserId");
        }
    }
}
