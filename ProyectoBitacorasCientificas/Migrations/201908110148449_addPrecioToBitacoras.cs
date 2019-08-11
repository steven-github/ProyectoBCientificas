namespace ProyectoBitacorasCientificas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addPrecioToBitacoras : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bitacoras", "precio", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Bitacoras", "precio");
        }
    }
}
