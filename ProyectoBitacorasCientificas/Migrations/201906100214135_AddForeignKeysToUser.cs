namespace ProyectoBitacorasCientificas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddForeignKeysToUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.NivelAcademicoes", "userId", c => c.Int(nullable: false));
            AddColumn("dbo.NivelAcademicoes", "ApplicationUser_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Puestoes", "userId", c => c.Int(nullable: false));
            AddColumn("dbo.Puestoes", "ApplicationUser_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.RolesLaboratorios", "userId", c => c.Int(nullable: false));
            AddColumn("dbo.RolesLaboratorios", "ApplicationUser_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.NivelAcademicoes", "ApplicationUser_Id");
            CreateIndex("dbo.Puestoes", "ApplicationUser_Id");
            CreateIndex("dbo.RolesLaboratorios", "ApplicationUser_Id");
            AddForeignKey("dbo.NivelAcademicoes", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Puestoes", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.RolesLaboratorios", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RolesLaboratorios", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Puestoes", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.NivelAcademicoes", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.RolesLaboratorios", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Puestoes", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.NivelAcademicoes", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.RolesLaboratorios", "ApplicationUser_Id");
            DropColumn("dbo.RolesLaboratorios", "userId");
            DropColumn("dbo.Puestoes", "ApplicationUser_Id");
            DropColumn("dbo.Puestoes", "userId");
            DropColumn("dbo.NivelAcademicoes", "ApplicationUser_Id");
            DropColumn("dbo.NivelAcademicoes", "userId");
        }
    }
}
