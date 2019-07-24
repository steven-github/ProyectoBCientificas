namespace ProyectoBitacorasCientificas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removingUserFromRolesLab : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RolesLaboratorios", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.RolesLaboratorios", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.RolesLaboratorios", "ApplicationUserId");
            DropColumn("dbo.RolesLaboratorios", "ApplicationUser_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RolesLaboratorios", "ApplicationUser_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.RolesLaboratorios", "ApplicationUserId", c => c.Int(nullable: false));
            CreateIndex("dbo.RolesLaboratorios", "ApplicationUser_Id");
            AddForeignKey("dbo.RolesLaboratorios", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
