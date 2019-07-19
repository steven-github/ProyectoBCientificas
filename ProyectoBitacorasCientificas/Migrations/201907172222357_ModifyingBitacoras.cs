namespace ProyectoBitacorasCientificas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyingBitacoras : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bitacoras",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        prefijo = c.String(),
                        nombreExperimento = c.String(),
                        Fecha = c.String(),
                        ProyectosId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Proyectos", t => t.ProyectosId, cascadeDelete: true)
                .Index(t => t.ProyectosId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bitacoras", "ProyectosId", "dbo.Proyectos");
            DropIndex("dbo.Bitacoras", new[] { "ProyectosId" });
            DropTable("dbo.Bitacoras");
        }
    }
}
