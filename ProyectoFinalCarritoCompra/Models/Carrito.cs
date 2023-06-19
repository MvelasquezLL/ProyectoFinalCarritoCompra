using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProyectoFinalCarritoCompra.Models
{

    public class CarritoView
    {
        public int Cantidad { get; set; }
        public int IdProducto { get; set; }
        public decimal Precio { get; set; }
        public string ImgenProducto { get; set; }
        public string NombreProducto { get; set; }

    }
}