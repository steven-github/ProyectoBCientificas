namespace ProyectoBitacorasCientificas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateNivelAcademicos : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.NivelAcademicoes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nombre = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.NivelAcademicoes");
        }
    }
}
