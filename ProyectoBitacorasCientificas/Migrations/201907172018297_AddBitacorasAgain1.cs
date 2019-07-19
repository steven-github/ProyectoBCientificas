namespace ProyectoBitacorasCientificas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBitacorasAgain1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Bitacora", "Proyectos_id", "dbo.Proyectos");
            DropIndex("dbo.Bitacora", new[] { "Proyectos_id" });
            RenameColumn(table: "dbo.Bitacora", name: "Proyectos_id", newName: "ProyectosId");
            AlterColumn("dbo.Bitacora", "ProyectosId", c => c.Int(nullable: false));
            CreateIndex("dbo.Bitacora", "ProyectosId");
            AddForeignKey("dbo.Bitacora", "ProyectosId", "dbo.Proyectos", "id", cascadeDelete: true);
            DropColumn("dbo.Bitacora", "ProyectoId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Bitacora", "ProyectoId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Bitacora", "ProyectosId", "dbo.Proyectos");
            DropIndex("dbo.Bitacora", new[] { "ProyectosId" });
            AlterColumn("dbo.Bitacora", "ProyectosId", c => c.Int());
            RenameColumn(table: "dbo.Bitacora", name: "ProyectosId", newName: "Proyectos_id");
            CreateIndex("dbo.Bitacora", "Proyectos_id");
            AddForeignKey("dbo.Bitacora", "Proyectos_id", "dbo.Proyectos", "id");
        }
    }
}
