namespace ProyectoBitacorasCientificas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removingCustomPropertiesFromApplicationUser : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AspNetUsers", "nombre");
            DropColumn("dbo.AspNetUsers", "primerApellido");
            DropColumn("dbo.AspNetUsers", "segundoApellido");
            DropColumn("dbo.AspNetUsers", "telefono");
            DropColumn("dbo.AspNetUsers", "nickName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "nickName", c => c.String());
            AddColumn("dbo.AspNetUsers", "telefono", c => c.String());
            AddColumn("dbo.AspNetUsers", "segundoApellido", c => c.String());
            AddColumn("dbo.AspNetUsers", "primerApellido", c => c.String());
            AddColumn("dbo.AspNetUsers", "nombre", c => c.String());
        }
    }
}
