namespace ProyectoBitacorasCientificas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifyingNivelAcademico : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.NivelAcademicoes", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.NivelAcademicoes", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.NivelAcademicoes", "userId");
            DropColumn("dbo.NivelAcademicoes", "ApplicationUser_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.NivelAcademicoes", "ApplicationUser_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.NivelAcademicoes", "userId", c => c.Int(nullable: false));
            CreateIndex("dbo.NivelAcademicoes", "ApplicationUser_Id");
            AddForeignKey("dbo.NivelAcademicoes", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
