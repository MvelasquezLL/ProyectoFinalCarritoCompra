using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProyectoFinalCarritoCompra.Models
{
    [Table("Producto")]
    public class Producto
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Ingrese el Código de Barra")]
        [MaxLength(12, ErrorMessage = "Excede el limite de caracteres.")]
        public string CodBarra { get; set; }
        [Required(ErrorMessage = "Ingrese el nombre del producto")]
        [MaxLength(50, ErrorMessage = "Excede el limite de caracteres.")]
        public string Nombre { get; set; }

        [DataType(DataType.MultilineText)]
        [MaxLength(100, ErrorMessage = "El largo máximo es de 100")]
        public string Descripcion { get; set;}

        [Required(ErrorMessage = "Ingrese el Stock del Producto")]
        [Range(0, 100, ErrorMessage = "El Stock no puede ser menor que cero")]
        public int Stock { get; set; }

        [Required(ErrorMessage = "Ingrese el Precio del Producto")]
        [Range(0.01, 10000000, ErrorMessage = "El precio debe ser mayor que cero")]
        public decimal Precio { get; set; }
        
        public string Imagen { get; set; }

        [ForeignKey("Marca")]
        public int idMarca { get; set; }
        public virtual Marca Marca { get; set; }

        [ForeignKey("Categoria")]
        public int idCategoria { get; set; }
        public virtual Categoria Categoria { get; set; }

    }
}