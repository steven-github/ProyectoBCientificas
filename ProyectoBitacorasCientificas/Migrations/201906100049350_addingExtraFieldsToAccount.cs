namespace ProyectoBitacorasCientificas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingExtraFieldsToAccount : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "nombre", c => c.String());
            AddColumn("dbo.AspNetUsers", "primerApellido", c => c.String());
            AddColumn("dbo.AspNetUsers", "segundoApellido", c => c.String());
            AddColumn("dbo.AspNetUsers", "telefono", c => c.String());
            AddColumn("dbo.AspNetUsers", "nickName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "nickName");
            DropColumn("dbo.AspNetUsers", "telefono");
            DropColumn("dbo.AspNetUsers", "segundoApellido");
            DropColumn("dbo.AspNetUsers", "primerApellido");
            DropColumn("dbo.AspNetUsers", "nombre");
        }
    }
}
