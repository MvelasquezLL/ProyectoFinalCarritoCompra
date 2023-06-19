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
        public string Nombre { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public DateTime Fecha_Compra { get; set; }
        public string idUsuario { get; set; }

    }
}