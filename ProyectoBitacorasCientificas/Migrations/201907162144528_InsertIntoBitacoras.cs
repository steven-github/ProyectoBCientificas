namespace ProyectoBitacorasCientificas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InsertIntoBitacoras : DbMigration
    {
        public override void Up()
        {
            Sql("  INSERT Into [aspnet-ProyectoBitacorasCientificas-20190609040316].[dbo].[Bitacora]" +
                "(prefijo, fecha, ProyectosId, nombreExperimento)" +
                "VALUES" +
                "('bit', '20120618 10:34:09 AM', 1, 'Experimentando')," +
                "('bit', '20130618 10:34:09 AM', 1, 'Experimentando2')," +
                "('bit', '20140618 10:34:09 AM', 1, 'Experimentando3')" +
                "; ");
        }
        
        public override void Down()
        {
        }
    }
}
