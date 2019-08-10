namespace ProyectoBitacorasCientificas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RolesLabAddNivelAcademico : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RolesLaboratorios", "nivelAcademico", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.RolesLaboratorios", "nivelAcademico");
        }
    }
}
