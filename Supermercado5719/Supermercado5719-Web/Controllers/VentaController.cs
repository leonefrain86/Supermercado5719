using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Supermercado5719_Web.Models;
using Supermercado5719_Biblioteca;

namespace Supermercado5719_Web.Controllers
{
    public class VentaController : Controller
    {
        private readonly LiteDbContext db;
        public VentaController(LiteDbContext db)
        {
            this.db = db;
        }

       [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        //Realizar Ventas
        [HttpGet]
        public IActionResult RealizarVenta()
        {


            return View("RealizarVenta");
        }

        [HttpPost]
        public IActionResult RealizarVenta(Venta unaVenta)
        {
            //LLamando a la base de datos principal
            var master = db.Context.GetCollection<Supermercado>("supermercado");
            var supermercado = master.FindAll().FirstOrDefault();
            //

            var caja = supermercado.cajas.FirstOrDefault(x => x.numCaja == unaVenta.numCaja);

            caja.ventas = new List<Venta>();
            caja.ventas.Add(unaVenta);

            master.Update(supermercado);

            ViewBag.venta = unaVenta;

            //return RedirectToAction("AgregarArticulo", unaVenta);
            return View("AgregarArticulo");
        }

        //Agregar Articulo
        [HttpGet]
        public IActionResult AgregarArticulo()
        {
            return View("AgregarArticulo");
        }

        [HttpPost]
        public IActionResult AgregarArticulo(AgregarArticulo agregarArticulo)
        {
            //LLamando a la base de datos principal
            var master = db.Context.GetCollection<Supermercado>("supermercado");
            var supermercado = master.FindAll().FirstOrDefault();
            //

            var ArticuloVendido = supermercado.inventario.stockArticulos.FirstOrDefault(x => x.articulo.codigoBarra == agregarArticulo.codigoBarra);

            if (ArticuloVendido.stock - agregarArticulo.unidades < 0)
                throw new Exception("Error el las unidades a ver son mayores al stock");

            supermercado.inventario.stockArticulos.FirstOrDefault(x => x.articulo.codigoBarra == agregarArticulo.codigoBarra).stock = ArticuloVendido.stock - agregarArticulo.unidades;

            master.Update(supermercado);
        
            return RedirectToAction("RealizarVenta");
        }
    }
}