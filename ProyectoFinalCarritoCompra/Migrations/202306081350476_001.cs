namespace ProyectoFinalCarritoCompra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _001 : DbMigration
    {
        public override void Up()
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
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.idUsuario)
                .ForeignKey("dbo.Producto", t => t.idProducto, cascadeDelete: true)
                .Index(t => t.idUsuario)
                .Index(t => t.idProducto);
            
            CreateTable(
                "dbo.Producto",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CodBarra = c.String(nullable: false, maxLength: 12),
                        Nombre = c.String(nullable: false, maxLength: 25),
                        Descripcion = c.String(maxLength: 100),
                        Stock = c.Int(nullable: false),
                        Precio = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Imagen = c.String(),
                        idMarca = c.Int(nullable: false),
                        idCategoria = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categoria", t => t.idCategoria, cascadeDelete: true)
                .ForeignKey("dbo.Marca", t => t.idMarca, cascadeDelete: true)
                .Index(t => t.idMarca)
                .Index(t => t.idCategoria);
            
            CreateTable(
                "dbo.Categoria",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NombreCat = c.String(nullable: false, maxLength: 35),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Marca",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NombreMarca = c.String(nullable: false, maxLength: 35),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Ciudad",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NombreCiu = c.String(nullable: false),
                        idRegion = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Region", t => t.idRegion, cascadeDelete: true)
                .Index(t => t.idRegion);
            
            CreateTable(
                "dbo.Region",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NombreReg = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Compra",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Folio = c.Int(nullable: false),
                        Nombre = c.String(nullable: false, maxLength: 25),
                        Cantidad = c.Int(nullable: false),
                        Precio = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Fecha_Compra = c.DateTime(nullable: false),
                        idUsuario = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.idUsuario)
                .Index(t => t.idUsuario);
            
            CreateTable(
                "dbo.DetalleCompra",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Cantidad = c.Int(nullable: false),
                        Total = c.Int(nullable: false),
                        idProducto = c.Int(nullable: false),
                        idCompra = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Compra", t => t.idCompra, cascadeDelete: true)
                .ForeignKey("dbo.Producto", t => t.idProducto, cascadeDelete: true)
                .Index(t => t.idProducto)
                .Index(t => t.idCompra);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DetalleCompra", "idProducto", "dbo.Producto");
            DropForeignKey("dbo.DetalleCompra", "idCompra", "dbo.Compra");
            DropForeignKey("dbo.Compra", "idUsuario", "dbo.AspNetUsers");
            DropForeignKey("dbo.Ciudad", "idRegion", "dbo.Region");
            DropForeignKey("dbo.Carrito", "idProducto", "dbo.Producto");
            DropForeignKey("dbo.Producto", "idMarca", "dbo.Marca");
            DropForeignKey("dbo.Producto", "idCategoria", "dbo.Categoria");
            DropForeignKey("dbo.Carrito", "idUsuario", "dbo.AspNetUsers");
            DropIndex("dbo.DetalleCompra", new[] { "idCompra" });
            DropIndex("dbo.DetalleCompra", new[] { "idProducto" });
            DropIndex("dbo.Compra", new[] { "idUsuario" });
            DropIndex("dbo.Ciudad", new[] { "idRegion" });
            DropIndex("dbo.Producto", new[] { "idCategoria" });
            DropIndex("dbo.Producto", new[] { "idMarca" });
            DropIndex("dbo.Carrito", new[] { "idProducto" });
            DropIndex("dbo.Carrito", new[] { "idUsuario" });
            DropTable("dbo.DetalleCompra");
            DropTable("dbo.Compra");
            DropTable("dbo.Region");
            DropTable("dbo.Ciudad");
            DropTable("dbo.Marca");
            DropTable("dbo.Categoria");
            DropTable("dbo.Producto");
            DropTable("dbo.Carrito");
        }
    }
}
