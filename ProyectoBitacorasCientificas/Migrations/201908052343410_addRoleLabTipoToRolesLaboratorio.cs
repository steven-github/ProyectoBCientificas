namespace ProyectoBitacorasCientificas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addRoleLabTipoToRolesLaboratorio : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RolesLaboratorios", "tipoRol", c => c.String());
            AddColumn("dbo.RolesLaboratorios", "puesto", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.RolesLaboratorios", "puesto");
            DropColumn("dbo.RolesLaboratorios", "tipoRol");
        }
    }
}
