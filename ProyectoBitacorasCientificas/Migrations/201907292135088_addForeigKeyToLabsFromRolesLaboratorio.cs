namespace ProyectoBitacorasCientificas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addForeigKeyToLabsFromRolesLaboratorio : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RolesLaboratorios", "LaboratorioId", "dbo.Laboratorios");
            DropIndex("dbo.RolesLaboratorios", new[] { "LaboratorioId" });
            AddColumn("dbo.RolesLaboratorios", "LabsId", c => c.Int(nullable: false));
            CreateIndex("dbo.RolesLaboratorios", "LabsId");
            AddForeignKey("dbo.RolesLaboratorios", "LabsId", "dbo.Labs", "id", cascadeDelete: true);
            DropColumn("dbo.RolesLaboratorios", "LaboratorioId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RolesLaboratorios", "LaboratorioId", c => c.Int(nullable: false));
            DropForeignKey("dbo.RolesLaboratorios", "LabsId", "dbo.Labs");
            DropIndex("dbo.RolesLaboratorios", new[] { "LabsId" });
            DropColumn("dbo.RolesLaboratorios", "LabsId");
            CreateIndex("dbo.RolesLaboratorios", "LaboratorioId");
            AddForeignKey("dbo.RolesLaboratorios", "LaboratorioId", "dbo.Laboratorios", "id", cascadeDelete: true);
        }
    }
}
