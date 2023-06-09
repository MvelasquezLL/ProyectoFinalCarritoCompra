using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProyectoFinalCarritoCompra.Models
{
    [Table("Compra")]
    public class Compra
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Ingrese el numero del Folio")]
        [Range(0, 10000000, ErrorMessage = "El folio no puede ser menor que cero")]
        public int Folio { get; set; }

        [Required(ErrorMessage = "Ingrese el nombre del producto")]
        [MaxLength(25, ErrorMessage = "Excede el limite de caracteres.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Ingrese la cantidad del Producto")]
        [Range(1, 100, ErrorMessage = "La cantidad no puede ser menor que 1")]
        public int Cantidad { get; set; }

        [Required(ErrorMessage = "Ingrese el Precio del Producto")]
        [Range(0.01, 10000000, ErrorMessage = "El precio debe ser mayor que cero")]
        public decimal Precio { get; set; }
        public DateTime Fecha_Compra { get; set; }

        [ForeignKey("ApplicationUser")]
        public string idUsuario { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

    }
}