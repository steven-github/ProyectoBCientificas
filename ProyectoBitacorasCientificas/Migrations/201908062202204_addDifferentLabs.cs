namespace ProyectoBitacorasCientificas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addDifferentLabs : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[Labs] ( [nombre]) VALUES (N'Heredia')
INSERT INTO [dbo].[Labs] ([nombre]) VALUES (N'Cartago')
INSERT INTO [dbo].[Labs] ( [nombre]) VALUES (N'San Jose')
");
        }
        
        public override void Down()
        {
        }
    }
}
