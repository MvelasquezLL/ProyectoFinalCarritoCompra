using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProyectoFinalCarritoCompra.Models
{
    [Table("DetalleCompra")]
    public class DetalleCompra
    {
        [Key]
        public int Id { get; set; }
        public int Cantidad { get; set; }
        public int Total { get; set; }

        [ForeignKey("Producto")]
        public int idProducto { get; set; }
        public virtual Producto Producto { get; set; }

        [ForeignKey("Compra")]
        public int idCompra { get; set; }
        public virtual Compra Compra { get; set; }
    }
}