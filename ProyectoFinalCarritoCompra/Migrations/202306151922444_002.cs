namespace ProyectoFinalCarritoCompra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _002 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Producto", "Nombre", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Producto", "Nombre", c => c.String(nullable: false, maxLength: 25));
        }
    }
}
