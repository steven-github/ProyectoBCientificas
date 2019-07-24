namespace ProyectoBitacorasCientificas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddApplicationUserToBitacoras : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bitacoras", "ApplicationUserId", c => c.Int(nullable: false));
            AddColumn("dbo.Bitacoras", "ApplicationUser_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Bitacoras", "ApplicationUser_Id");
            AddForeignKey("dbo.Bitacoras", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bitacoras", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Bitacoras", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.Bitacoras", "ApplicationUser_Id");
            DropColumn("dbo.Bitacoras", "ApplicationUserId");
        }
    }
}
