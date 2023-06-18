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
            var producto = db.Producto.Include(p => p.Categoria).Include(p => p.Marca);
            return View(await producto.ToListAsync());
        }
        public ActionResult Mantenedores()
        {

            return View();
        }


    }
}