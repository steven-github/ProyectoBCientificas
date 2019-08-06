namespace ProyectoBitacorasCientificas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeTipoRolesLab : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.TipoRolLaboratorios");
        }
        
        public override void Down()
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
    }
}
