namespace ProyectoBitacorasCientificas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addBitacoraFKToFactura : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Facturas", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Facturas", new[] { "ApplicationUser_Id" });
            AddColumn("dbo.Facturas", "BitacoraId", c => c.Int(nullable: false));
            CreateIndex("dbo.Facturas", "BitacoraId");
            AddForeignKey("dbo.Facturas", "BitacoraId", "dbo.Bitacoras", "id", cascadeDelete: true);
            DropColumn("dbo.Facturas", "ClienteId");
            DropColumn("dbo.Facturas", "ApplicationUser_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Facturas", "ApplicationUser_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Facturas", "ClienteId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Facturas", "BitacoraId", "dbo.Bitacoras");
            DropIndex("dbo.Facturas", new[] { "BitacoraId" });
            DropColumn("dbo.Facturas", "BitacoraId");
            CreateIndex("dbo.Facturas", "ApplicationUser_Id");
            AddForeignKey("dbo.Facturas", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
