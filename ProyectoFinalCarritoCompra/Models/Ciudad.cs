using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProyectoFinalCarritoCompra.Models
{
    [Table("Ciudad")]
    public class Ciudad
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string NombreCiu { get; set; }

        [ForeignKey("Region")]
        public int idRegion { get; set; }
        public virtual Region Region { get; set; }
    }
}