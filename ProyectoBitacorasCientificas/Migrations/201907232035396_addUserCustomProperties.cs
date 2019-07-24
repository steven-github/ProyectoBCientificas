namespace ProyectoBitacorasCientificas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addUserCustomProperties : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "nombre", c => c.String(nullable: false));
            AddColumn("dbo.AspNetUsers", "primerApellido", c => c.String(nullable: false));
            AddColumn("dbo.AspNetUsers", "segundoApellido", c => c.String(nullable: false));
            AddColumn("dbo.AspNetUsers", "telefono", c => c.String());
            AddColumn("dbo.AspNetUsers", "nickname", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "nickname");
            DropColumn("dbo.AspNetUsers", "telefono");
            DropColumn("dbo.AspNetUsers", "segundoApellido");
            DropColumn("dbo.AspNetUsers", "primerApellido");
            DropColumn("dbo.AspNetUsers", "nombre");
        }
    }
}
