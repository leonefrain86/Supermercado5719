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
        public IActionResult AgregarArticulo()
        {
            //var articulos = db.Context.GetCollection<Articulo>("Articulo");

            //ViewBag.CantidadArticulos = articulos.Count();

            return View("AgregarArticulo");
        }
        [HttpGet]
        public IActionResult Agregar()
        {
            return View("Agregar");
        }
        [HttpPost]
        public IActionResult Agregar(Articulo articulo)
        {
            var articulos = db.Context.GetCollection<Articulo>("Articulo");
            
            articulos.Insert(articulo);

            return RedirectToAction("AgregarArticulo", articulos.FindAll());
        }
        [HttpGet]
        public IActionResult Editar(int id)
        {
            var articulos = db.Context.GetCollection<Articulo>("Articulo").FindAll();

            var articulo = articulos.FirstOrDefault(x => x.idArticulo == id);

            return View("Editar", articulo);
        }
        [HttpPost]
        public IActionResult Editar(Articulo articulo)
        {
            var articulos = db.Context.GetCollection<Articulo>("Articulo");

            articulos.Update(articulo);

            return RedirectToAction("AgregarArticulo", articulos.FindAll());
        }
        public IActionResult Eliminar(int id)
        {
            var articulos = db.Context.GetCollection<Articulo>("Articulo");
            
            articulos.Delete(x => x.idArticulo == id);

            return RedirectToAction("AgregarArticulos", articulos.FindAll());
        }
    }
}