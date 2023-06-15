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

        public int Precio { get; set; }

        public string Producto { get; set; }
        public string idUsuario { get; set; }
     
        public int idProducto { get; set; }

    }
}