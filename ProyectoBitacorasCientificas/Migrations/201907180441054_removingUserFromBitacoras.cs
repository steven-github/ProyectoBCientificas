namespace ProyectoBitacorasCientificas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removingUserFromBitacoras : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Bitacoras", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Bitacoras", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.Bitacoras", "ApplicationUserId");
            DropColumn("dbo.Bitacoras", "ApplicationUser_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Bitacoras", "ApplicationUser_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Bitacoras", "ApplicationUserId", c => c.Int(nullable: false));
            CreateIndex("dbo.Bitacoras", "ApplicationUser_Id");
            AddForeignKey("dbo.Bitacoras", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
