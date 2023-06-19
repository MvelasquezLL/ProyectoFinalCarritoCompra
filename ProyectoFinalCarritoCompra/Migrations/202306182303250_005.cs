namespace ProyectoFinalCarritoCompra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _005 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Compra", "idUsuario", "dbo.AspNetUsers");
            DropIndex("dbo.Compra", new[] { "idUsuario" });
            AlterColumn("dbo.Compra", "idUsuario", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Compra", "idUsuario", c => c.String(maxLength: 128));
            CreateIndex("dbo.Compra", "idUsuario");
            AddForeignKey("dbo.Compra", "idUsuario", "dbo.AspNetUsers", "Id");
        }
    }
}
