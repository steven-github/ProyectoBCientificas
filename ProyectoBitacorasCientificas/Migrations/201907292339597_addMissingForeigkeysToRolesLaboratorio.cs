namespace ProyectoBitacorasCientificas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addMissingForeigkeysToRolesLaboratorio : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TipoRolLaboratorios",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nombre = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TipoRolLaboratorios");
        }
    }
}
