namespace ProyectoBitacorasCientificas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBitacorasRegistro : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BitacoraRegistroes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        descripcion = c.String(),
                        entidadRelacionada = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.BitacoraRegistroes");
        }
    }
}
