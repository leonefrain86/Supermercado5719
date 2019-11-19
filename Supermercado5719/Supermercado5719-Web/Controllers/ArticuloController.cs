using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Supermercado5719_Biblioteca;
using Supermercado5719_Web.Models;
using System.Collections.Generic;

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
            //LLamando a la base de datos principal
            var master = db.Context.GetCollection<Supermercado>("supermercado");
            var supermercado = master.FindAll().FirstOrDefault();
            //
            
            return View("Index", supermercado.inventario.stockArticulos);
        }

        //Agregar Articulo al inventario
        [HttpGet]
        public IActionResult AgregarArticulo()
        {
            return View("AgregarArticulo");
        }

        [HttpPost]
        public IActionResult AgregarArticulo(Articulo articulo)
        {
            //LLamando a la base de datos principal
            var master = db.Context.GetCollection<Supermercado>("supermercado");
            var supermercado = master.FindAll().FirstOrDefault();
            //
            bool Comprobador = supermercado.inventario.stockArticulos.Exists(x => x.articulo.codigoBarra == articulo.codigoBarra);
            if (Comprobador == true)
            {
                supermercado.inventario.stockArticulos.FirstOrDefault(x => x.articulo.codigoBarra == articulo.codigoBarra).stock++;
            }
            else
            {
                var stockArticulo = new stockArticulos();
                stockArticulo.articulo = articulo;
                stockArticulo.stock++;
                supermercado.inventario.stockArticulos.Add(stockArticulo);
            }
            
            master.Update(supermercado);

            return RedirectToAction("Index", master.FindAll());
        }


        // Editar Articulo
        [HttpGet]
        public IActionResult Editar(int id)
        {
            //LLamando a la base de datos principal
            var master = db.Context.GetCollection<Supermercado>("supermercado");
            var supermercado = master.FindAll().FirstOrDefault();
            //
            var articulo = supermercado.inventario.stockArticulos.FirstOrDefault(x => x.articulo.id == id);


            return View("EditarArticulo", articulo);
        }
        [HttpPost]
        public IActionResult Editar(Articulo articulo)
        {
            //LLamando a la base de datos principal
            var master = db.Context.GetCollection<Supermercado>("supermercado");
            var supermercado = master.FindAll().FirstOrDefault();
            //

            supermercado.inventario.stockArticulos.FirstOrDefault(x => x.articulo.id == articulo.id).articulo = articulo;

            master.Update(supermercado);

            return RedirectToAction("Index", master.FindAll());
        }

        // Eliminar Articulo
        public IActionResult Eliminar(int id)
        {
            //LLamando a la base de datos principal
            var master = db.Context.GetCollection<Supermercado>("supermercado");
            var supermercado = master.FindAll().FirstOrDefault();
            //

            var articuloEliminado = supermercado.inventario.stockArticulos.FirstOrDefault(x => x.articulo.id == id);
            supermercado.inventario.stockArticulos.Remove(articuloEliminado);

            master.Update(supermercado);

            return RedirectToAction("Index", master.FindAll());
        }
    }
}