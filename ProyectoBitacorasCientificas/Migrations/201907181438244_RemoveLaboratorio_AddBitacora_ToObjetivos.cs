namespace ProyectoBitacorasCientificas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveLaboratorio_AddBitacora_ToObjetivos : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Objetivos", "LaboratorioId", "dbo.Laboratorios");
            DropIndex("dbo.Objetivos", new[] { "LaboratorioId" });
            AddColumn("dbo.Objetivos", "BitacoraId", c => c.Int(nullable: false));
            CreateIndex("dbo.Objetivos", "BitacoraId");
            AddForeignKey("dbo.Objetivos", "BitacoraId", "dbo.Bitacoras", "id", cascadeDelete: true);
            DropColumn("dbo.Objetivos", "LaboratorioId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Objetivos", "LaboratorioId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Objetivos", "BitacoraId", "dbo.Bitacoras");
            DropIndex("dbo.Objetivos", new[] { "BitacoraId" });
            DropColumn("dbo.Objetivos", "BitacoraId");
            CreateIndex("dbo.Objetivos", "LaboratorioId");
            AddForeignKey("dbo.Objetivos", "LaboratorioId", "dbo.Laboratorios", "id", cascadeDelete: true);
        }
    }
}
