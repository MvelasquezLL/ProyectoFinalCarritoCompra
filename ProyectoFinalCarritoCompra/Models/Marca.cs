using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProyectoFinalCarritoCompra.Models
{
    [Table("Marca")]
    public class Marca
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Debe ingresar una marca.")]
        [MaxLength(35, ErrorMessage = "Excede la cantidad de caracteres.")]
        public string NombreMarca { get; set; }
    }
}