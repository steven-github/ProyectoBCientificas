namespace ProyectoBitacorasCientificas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLaboratorioToObjetivos : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Objetivos", "LaboratorioId", c => c.Int(nullable: false));
            CreateIndex("dbo.Objetivos", "LaboratorioId");
            AddForeignKey("dbo.Objetivos", "LaboratorioId", "dbo.Laboratorios", "id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Objetivos", "LaboratorioId", "dbo.Laboratorios");
            DropIndex("dbo.Objetivos", new[] { "LaboratorioId" });
            DropColumn("dbo.Objetivos", "LaboratorioId");
        }
    }
}
