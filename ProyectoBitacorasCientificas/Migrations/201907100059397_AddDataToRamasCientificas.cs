namespace ProyectoBitacorasCientificas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDataToRamasCientificas : DbMigration
    {
        public override void Up()
        {

            Sql("INSERT INTO [dbo].[TipoRamaCientificas]" +
                "([nombre])" +
                "VALUES" +
                "('Biologia'), " +
                "('Ecologia'), " +
                "('Marinologia'); ");

            Sql("INSERT INTO [dbo].[RamaCientificas]" +
                "([prefijo]" +
                ",[nombre]" +
                ",[TipoRamaCientificaId])" +
                "VALUES" +
                "('ram'," +
                "'Sexualidad'," +
                "1), " +
                "('ram'," +
                "'Pescadologia'," +
                "2), " +
                "('ram'," +
                "'Haciendo'," +
                "3)");

            Sql("INSERT INTO [dbo].[Proyectos]" +
                "([prefijo]" +
                ",[nombre]" +
                ",[RamaCientificaId])" +
                "VALUES" +
                "('pro'," +
                "'HellBlade'," +
                "1), " +
                "('pro'," +
                "'T-Virus'," +
                "2)");
        }
        
        public override void Down()
        {
        }
    }
}
