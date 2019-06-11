namespace ProyectoBitacorasCientificas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddModelForEasyPay : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Facturas",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        fechaEmision = c.DateTime(nullable: false),
                        monto = c.Double(nullable: false),
                        ClienteId = c.Int(nullable: false),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Facturas", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Facturas", new[] { "ApplicationUser_Id" });
            DropTable("dbo.Facturas");
        }
    }
}
