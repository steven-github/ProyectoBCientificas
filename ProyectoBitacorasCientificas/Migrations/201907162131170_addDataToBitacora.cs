namespace ProyectoBitacorasCientificas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addDataToBitacora : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bitacora", "nombreExperimento", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Bitacora", "nombreExperimento");
        }
    }
}
