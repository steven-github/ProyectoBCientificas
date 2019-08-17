namespace ProyectoBitacorasCientificas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Updates : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Facturas", "IdPaypal", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Facturas", "IdPaypal");
        }
    }
}
