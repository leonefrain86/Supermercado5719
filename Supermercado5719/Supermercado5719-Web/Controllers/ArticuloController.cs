using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Supermercado5719_Biblioteca;
using Supermercado5719_Web.Models;

namespace Supermercado5719_Web.Controllers
{

    public class ArticuloController : Controller
    {
        private readonly LiteDbContext db;
        public ArticuloController(LiteDbContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var articulos = db.Context.GetCollection<stockArticulos>("Articulo");

            ViewBag.CantidadArticulos = articulos.Count();

            return View("Index", articulos.FindAll());
        }
        [HttpGet]
        public IActionResult AgregarArticulo()
        {
            return View("AgregarArticulo");
        }
        [HttpPost]
        public IActionResult AgregarArticulo(Articulo articulo)
        {
            var articulos = db.Context.GetCollection<stockArticulos>("Articulo");
            var stockArticulo = new stockArticulos();
            stockArticulo.articulo = articulo;
            stockArticulo.stock++;
            articulos.Insert(stockArticulo);

            return RedirectToAction("Index", articulos.FindAll());
        }
        [HttpGet]
        public IActionResult Editar(int id)
        {
            var articulos = db.Context.GetCollection<stockArticulos>("Articulo").FindAll();

            var articulo = articulos.FirstOrDefault(x => x.id == id);

            return View("EditarArticulo", articulo);
        }
        [HttpPost]
        public IActionResult Editar(Articulo articulo)
        {
            var articulos = db.Context.GetCollection<stockArticulos>("Articulo");
            var stockArticulo = new stockArticulos();
            articulos.Update(stockArticulo);

            return RedirectToAction("Index", articulos.FindAll());
        }
        public IActionResult Eliminar(int id)
        {
            var articulos = db.Context.GetCollection<stockArticulos>("Articulo");
            
            articulos.Delete(x => x.id == id);

            return RedirectToAction("Index", articulos.FindAll());
        }
    }
}