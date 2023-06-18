using ProyectoFinalCarritoCompra.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ProyectoFinalCarritoCompra.Controllers
{
    
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            db.Ciudad.Add(new Ciudad { Id = 1, NombreCiu = "Arica", idRegion = 1 });
            db.Ciudad.Add(new Ciudad { Id = 2, NombreCiu = "Iquique", idRegion = 2 });
            db.Ciudad.Add(new Ciudad { Id = 3, NombreCiu = "Antofagasta", idRegion = 3 });
            db.Ciudad.Add(new Ciudad { Id = 4, NombreCiu = "Calama", idRegion = 3 });
            db.Ciudad.Add(new Ciudad { Id = 5, NombreCiu = "Copiapó", idRegion = 4 });
            db.Ciudad.Add(new Ciudad { Id = 6, NombreCiu = "Vallenar", idRegion = 4 });
            db.Ciudad.Add(new Ciudad { Id = 7, NombreCiu = "La Serena", idRegion = 5 });
            db.Ciudad.Add(new Ciudad { Id = 8, NombreCiu = "Coquimbo", idRegion = 5 });
            db.Ciudad.Add(new Ciudad { Id = 9, NombreCiu = "Valparaíso", idRegion = 6 });
            db.Ciudad.Add(new Ciudad { Id = 10, NombreCiu = "Viña del Mar", idRegion = 6 });
            db.Ciudad.Add(new Ciudad { Id = 11, NombreCiu = "Santiago", idRegion = 7 });
            db.Ciudad.Add(new Ciudad { Id = 12, NombreCiu = "Maipú", idRegion = 7 });
            db.Ciudad.Add(new Ciudad { Id = 13, NombreCiu = "Rancagua", idRegion = 8 });
            db.Ciudad.Add(new Ciudad { Id = 14, NombreCiu = "San Fernando", idRegion = 8 });
            db.Ciudad.Add(new Ciudad { Id = 15, NombreCiu = "Talca", idRegion = 9 });
            db.Ciudad.Add(new Ciudad { Id = 16, NombreCiu = "Curicó", idRegion = 9 });
            db.Ciudad.Add(new Ciudad { Id = 17, NombreCiu = "Chillán", idRegion = 10 });
            db.Ciudad.Add(new Ciudad { Id = 18, NombreCiu = "San Carlos", idRegion = 10 });
            db.Ciudad.Add(new Ciudad { Id = 19, NombreCiu = "Concepción", idRegion = 11 });
            db.Ciudad.Add(new Ciudad { Id = 20, NombreCiu = "Talcahuano", idRegion = 11 });
            db.Ciudad.Add(new Ciudad { Id = 21, NombreCiu = "Temuco", idRegion = 12 });
            db.Ciudad.Add(new Ciudad { Id = 22, NombreCiu = "Padre Las Casas", idRegion = 12 });
            db.Ciudad.Add(new Ciudad { Id = 23, NombreCiu = "Valdivia", idRegion = 13 });
            db.Ciudad.Add(new Ciudad { Id = 24, NombreCiu = "La Unión", idRegion = 13 });
            db.Ciudad.Add(new Ciudad { Id = 25, NombreCiu = "Puerto Montt", idRegion = 14 });
            db.Ciudad.Add(new Ciudad { Id = 26, NombreCiu = "Osorno", idRegion = 14 });
            db.Ciudad.Add(new Ciudad { Id = 27, NombreCiu = "Coyhaique", idRegion = 15 });
            db.Ciudad.Add(new Ciudad { Id = 28, NombreCiu = "Puerto Aysén", idRegion = 15 });
            db.Ciudad.Add(new Ciudad { Id = 29, NombreCiu = "Punta Arenas", idRegion = 16 });
            db.Ciudad.Add(new Ciudad { Id = 30, NombreCiu = "Puerto Natales", idRegion = 16 });

            db.SaveChanges();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public async Task<ActionResult> Productos()
        {
            if (HttpContext.Session["IdProductos"] == null)
            {
                List<int> IdProductos = new List<int>();
                HttpContext.Session["IdProductos"] = IdProductos;
            }
            var producto = db.Producto.Include(p => p.Categoria).Include(p => p.Marca);
            return View(await producto.ToListAsync());
        }
        public ActionResult Mantenedores()
        {

            return View();
        }

        [Authorize]
        public async Task<ActionResult> AddProducto(int id)
        {
            List<int> lista = (List<int>)HttpContext.Session["IdProductos"];
            lista.Add(id);
            HttpContext.Session["IdProductos"] = lista;
            return RedirectToAction("Productos");
        }

    }
}