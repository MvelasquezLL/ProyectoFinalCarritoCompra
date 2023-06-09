using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProyectoFinalCarritoCompra.Models
{
    [Table("Carrito")]
    public class Carrito
    {
        [Key]
        public int Id {get; set; }
        public int Cantidad { get; set; }

        [ForeignKey("ApplicationUser")]
        public string idUsuario { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        [ForeignKey("Producto")]
        public int idProducto { get; set; }
        public virtual Producto Producto { get; set; }

    }
}