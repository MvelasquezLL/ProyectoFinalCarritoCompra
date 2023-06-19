namespace ProyectoFinalCarritoCompra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _006 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Compra", "Nombre", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Compra", "Nombre", c => c.String(nullable: false, maxLength: 25));
        }
    }
}
