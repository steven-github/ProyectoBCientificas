namespace ProyectoBitacorasCientificas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removingBitacoras : DbMigration
    {
        public override void Up()
        {
            CreateTable(
               "dbo.Bitacora",
               c => new
               {
                   id = c.Int(nullable: false, identity: true),
                   prefijo = c.String(),
                   nombre = c.String(),
                   fecha = c.DateTime(),
                   ProyectoId = c.Int(nullable: false),
                   Proyectos_id = c.Int(),
               })
               .PrimaryKey(t => t.id);

            CreateIndex("dbo.Bitacora", "Proyectos_id");
            AddForeignKey("dbo.Bitacora", "Proyectos_id", "dbo.Proyectos", "id");

            DropForeignKey("dbo.Bitacora", "Proyectos_id", "dbo.Proyectos");
            DropIndex("dbo.Bitacora", new[] { "Proyectos_id" });
            DropTable("dbo.Bitacora");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Bitacora",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        prefijo = c.String(),
                        nombre = c.String(),
                        fecha = c.DateTime(),
                        ProyectoId = c.Int(nullable: false),
                        Proyectos_id = c.Int(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateIndex("dbo.Bitacora", "Proyectos_id");
            AddForeignKey("dbo.Bitacora", "Proyectos_id", "dbo.Proyectos", "id");
        }
    }
}
