namespace ProyectoBitacorasCientificas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addUserForeignKeyToRolesLab : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RolesLaboratorios", "ApplicationUserId", c => c.Int(nullable: false));
            AddColumn("dbo.RolesLaboratorios", "ApplicationUser_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.RolesLaboratorios", "ApplicationUser_Id");
            AddForeignKey("dbo.RolesLaboratorios", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RolesLaboratorios", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.RolesLaboratorios", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.RolesLaboratorios", "ApplicationUser_Id");
            DropColumn("dbo.RolesLaboratorios", "ApplicationUserId");
        }
    }
}
