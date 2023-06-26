using Microsoft.AspNet.Identity;
using ProyectoFinalCarritoCompra.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace ProyectoFinalCarritoCompra.Controllers
{
    public class CarritoController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Carrito
        public ActionResult Index()
        {
            if (HttpContext.Session["ListaCarrito"] == null)
            {
                List<CarritoView> IdProductos = new List<CarritoView>();
                HttpContext.Session["ListaCarrito"] = IdProductos;
            }
            if (HttpContext.Session["IdProductos"] != null)
            {
                List<int> lista = (List<int>)HttpContext.Session["IdProductos"];
                List<CarritoView> Actualista = (List<CarritoView>)HttpContext.Session["ListaCarrito"];
                CarritoView valida = new CarritoView();
                foreach (int item in lista)
                {
                    valida = Actualista.Where(p => p.IdProducto == item).FirstOrDefault();
                    if ( valida == null)
                    {
                        Producto prod = db.Producto.Find(item);
                        CarritoView productsView = new CarritoView();
                        productsView.NombreProducto = prod.Nombre;
                        productsView.ImgenProducto = prod.Imagen;
                        productsView.Precio = prod.Precio;
                        productsView.Cantidad = 1;
                        productsView.IdProducto = prod.Id;
                        Actualista.Add(productsView);
                    }
                    
                }
                HttpContext.Session["ListaCarrito"] = Actualista;
            }
            return View();
        }

        // GET: Carrito/Details/5
        public async Task<ActionResult> SumarCantidad(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            List<CarritoView> Actualista = (List<CarritoView>)HttpContext.Session["ListaCarrito"];
            CarritoView item = Actualista.Where(i => i.IdProducto == id).FirstOrDefault();
            Producto producto = db.Producto.Find(item.IdProducto);
            var indice = Actualista.IndexOf(item);
            if (item.Cantidad < producto.Stock)
            {
                item.Cantidad = item.Cantidad+1;
                Actualista.RemoveAt(indice);
                Actualista.Insert(indice, item);
                HttpContext.Session["ListaCarrito"] = Actualista;
            }
            return RedirectToAction("Index");
        }
        public async Task<ActionResult> RestarCantidad(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            List<CarritoView> Actualista = (List<CarritoView>)HttpContext.Session["ListaCarrito"];
            CarritoView item = Actualista.Where(i => i.IdProducto == id).FirstOrDefault();
            var indice = Actualista.IndexOf(item);
            if (item.Cantidad > 1)
            {
                item.Cantidad = item.Cantidad - 1;
                Actualista.RemoveAt(indice);
                Actualista.Insert(indice, item);
                HttpContext.Session["ListaCarrito"] = Actualista;
            }
            return RedirectToAction("Index");
        }
        public async Task<ActionResult> EliminarProducto(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            List<CarritoView> Actualista = (List<CarritoView>)HttpContext.Session["ListaCarrito"];
            List<int> lista = (List<int>)HttpContext.Session["IdProductos"];
            CarritoView item = Actualista.Where(i => i.IdProducto == id).FirstOrDefault();
            var indice = Actualista.IndexOf(item);
            lista.RemoveAt(indice);
            Actualista.RemoveAt(indice);
            HttpContext.Session["ListaCarrito"] = Actualista;
            HttpContext.Session["IdProductos"] = lista;
            return RedirectToAction("Index");
        }

        // GET: Carrito/
        public async Task<ActionResult> PostCompra()
        {
            Random rnd = new Random();
            int folio = rnd.Next(1, 10000000);
            List<CarritoView> Actualista = (List<CarritoView>)HttpContext.Session["ListaCarrito"];
            List<int> lista = (List<int>)HttpContext.Session["IdProductos"];
            foreach (CarritoView item in Actualista)
            {
                Compra compra = new Compra()
                {
                    Id = 1,
                    Nombre = item.NombreProducto,
                    Cantidad = item.Cantidad,
                    Precio = item.Precio,
                    Fecha_Compra = DateTime.Now,
                    idUsuario = User.Identity.GetUserId(),
                    Folio = folio
                };
                Producto prod = db.Producto.Where(x => x.Id == item.IdProducto).FirstOrDefault();
                prod.Stock = prod.Stock - item.Cantidad;
                db.Entry(prod).State = EntityState.Modified;
                db.Compra.Add(compra);
                db.SaveChanges();
            }
            lista.Clear();
            Actualista.Clear();
            HttpContext.Session["ListaCarrito"] = Actualista;
            HttpContext.Session["IdProductos"] = lista;
            return View();
        }

        // POST: Carrito/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Carrito/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Carrito/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Carrito/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Carrito/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
