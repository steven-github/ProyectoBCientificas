namespace ProyectoBitacorasCientificas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedDataForRolesLab : DbMigration
    {
        public override void Up()
        {
            Sql(@"
-- Laboratorios
INSERT INTO [dbo].[Laboratorios] ( [nombre], [lugar]) VALUES ( N'LABIN', N'Heredia')
INSERT INTO [dbo].[Laboratorios] ([nombre], [lugar]) VALUES (N'FURNITUE', N'Cartago')
INSERT INTO [dbo].[Laboratorios] ([nombre], [lugar]) VALUES ( N'Oscorp', N'Grecia')

-- Tipo Rol 
INSERT INTO [dbo].[TipoRolLaboratorios] ([nombre]) VALUES (N'Cientifico')
INSERT INTO [dbo].[TipoRolLaboratorios] ( [nombre]) VALUES ( N'Limpiador')
INSERT INTO [dbo].[TipoRolLaboratorios] ( [nombre]) VALUES ( N'Tester')
INSERT INTO [dbo].[TipoRolLaboratorios] ( [nombre]) VALUES ( N'Analista')

-- Puesto
INSERT INTO [dbo].[Puestoes] ( [nombre]) VALUES ( N'QA')
INSERT INTO [dbo].[Puestoes] ( [nombre]) VALUES ( N'Microbiologo')
INSERT INTO [dbo].[Puestoes] ( [nombre]) VALUES ( N'Conserje')
");
        }
        
        public override void Down()
        {
        }
    }
}
