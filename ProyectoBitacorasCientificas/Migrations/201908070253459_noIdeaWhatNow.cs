namespace ProyectoBitacorasCientificas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class noIdeaWhatNow : DbMigration
    {
        public override void Up()
        {
            //AddColumn("dbo.NivelAcademicoes", "userId", c => c.Int(nullable: false));
            //AddColumn("dbo.NivelAcademicoes", "ApplicationUser_Id", c => c.String(maxLength: 128));
            //CreateIndex("dbo.NivelAcademicoes", "ApplicationUser_Id");
            //AddForeignKey("dbo.NivelAcademicoes", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
            //DropColumn("dbo.RolesLaboratorios", "nivelAcademico");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RolesLaboratorios", "nivelAcademico", c => c.String());
            DropForeignKey("dbo.NivelAcademicoes", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.NivelAcademicoes", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.NivelAcademicoes", "ApplicationUser_Id");
            DropColumn("dbo.NivelAcademicoes", "userId");
        }
    }
}
