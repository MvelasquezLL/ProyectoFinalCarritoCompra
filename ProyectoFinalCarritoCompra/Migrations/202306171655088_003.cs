namespace ProyectoFinalCarritoCompra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _003 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Carrito", "idUsuario", "dbo.AspNetUsers");
            DropForeignKey("dbo.Carrito", "idProducto", "dbo.Producto");
            DropIndex("dbo.Carrito", new[] { "idUsuario" });
            DropIndex("dbo.Carrito", new[] { "idProducto" });
            DropTable("dbo.Carrito");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Carrito",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Cantidad = c.Int(nullable: false),
                        idUsuario = c.String(maxLength: 128),
                        idProducto = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.Carrito", "idProducto");
            CreateIndex("dbo.Carrito", "idUsuario");
            AddForeignKey("dbo.Carrito", "idProducto", "dbo.Producto", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Carrito", "idUsuario", "dbo.AspNetUsers", "Id");
        }
    }
}
