using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProyectoFinalCarritoCompra.Models;

namespace ProyectoFinalCarritoCompra.Controllers
{
    //ola esto es una pueba
    public class ProductoController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Producto
        public async Task<ActionResult> Index()
        {
            var producto = db.Producto.Include(p => p.Categoria).Include(p => p.Marca);
            return View(await producto.ToListAsync());
        }

        // GET: Producto/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producto producto = await db.Producto.FindAsync(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }

        // GET: Producto/Create
        public ActionResult Create()
        {
            ViewBag.idCategoria = new SelectList(db.Categoria, "Id", "NombreCat");
            ViewBag.idMarca = new SelectList(db.Marca, "Id", "NombreMarca");
            return View();
        }

        // POST: Producto/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,CodBarra,Nombre,Descripcion,Stock,Precio,Imagen,idMarca,idCategoria")] Producto producto)
        {
            if (ModelState.IsValid)
            {
                db.Producto.Add(producto);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.idCategoria = new SelectList(db.Categoria, "Id", "NombreCat", producto.idCategoria);
            ViewBag.idMarca = new SelectList(db.Marca, "Id", "NombreMarca", producto.idMarca);
            return View(producto);
        }

        // GET: Producto/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producto producto = await db.Producto.FindAsync(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            ViewBag.idCategoria = new SelectList(db.Categoria, "Id", "NombreCat", producto.idCategoria);
            ViewBag.idMarca = new SelectList(db.Marca, "Id", "NombreMarca", producto.idMarca);
            return View(producto);
        }

        // POST: Producto/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,CodBarra,Nombre,Descripcion,Stock,Precio,Imagen,idMarca,idCategoria")] Producto producto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(producto).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.idCategoria = new SelectList(db.Categoria, "Id", "NombreCat", producto.idCategoria);
            ViewBag.idMarca = new SelectList(db.Marca, "Id", "NombreMarca", producto.idMarca);
            return View(producto);
        }

        // GET: Producto/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producto producto = await db.Producto.FindAsync(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }

        // POST: Producto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Producto producto = await db.Producto.FindAsync(id);
            db.Producto.Remove(producto);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
