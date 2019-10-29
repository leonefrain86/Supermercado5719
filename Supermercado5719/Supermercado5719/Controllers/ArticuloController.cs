using System.Linq;
using ejemplomvc.Models;
using Microsoft.AspNetCore.Mvc;
using Supermercado5719.Models;

namespace Supermercado5719.Controllers
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
            var articulos = db.Context.GetCollection<Articulo>("supermercado5719");

            return View("Index", articulos.FindAll());
        }

        [HttpGet]
        public IActionResult Agregar()
        {
            return View("Agregar");
        }

        [HttpPost]
        public IActionResult Agregar(Articulo articulo)
        {
            var articulos = db.Context.GetCollection<Articulo>("supermercado5719");

            articulos.Insert(articulo);

            return RedirectToAction("Index", articulos.FindAll());
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            var articulos = db.Context.GetCollection<Articulo>("supermercado5719").FindAll();

            var articulo = articulos.FirstOrDefault(x => x.id == id);

            return View("Editar", articulo);
        }

        [HttpPost]
        public IActionResult Editar(Articulo articulo)
        {
            var articulos = db.Context.GetCollection<Articulo>("supermercado5719");

            articulos.Update(articulo);

            return RedirectToAction("Index", articulos.FindAll());
        }

        public IActionResult Eliminar(int id)
        {
            var articulos = db.Context.GetCollection<Articulo>("supermercado5719");

            articulos.Delete(x => x.id == id);

            return RedirectToAction("Index", articulos.FindAll());
        }
    }
}
