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
            var master = db.Context.GetCollection<Supermercado>("supermercado");

            var supermercado = new Supermercado()
            {
                cajas = new List<Caja>() { new Caja { numCaja = 1}, new Caja { numCaja = 2 }, new Caja { numCaja = 3 } , new Caja { numCaja = 4 }, new Caja { numCaja = 5 } },
                inventario = new Inventario()

            };

            master.Insert(supermercado);

            return View("RealizarVenta");
        }

        [HttpPost]
        public IActionResult RealizarVenta(Venta unaVenta)
        {
            var master = db.Context.GetCollection<Supermercado>("supermercado");

            var supermercado = master.FindAll().FirstOrDefault();

            var caja = supermercado.cajas.FirstOrDefault(x => x.numCaja == unaVenta.numCaja);

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
            var inventarios = db.Context.GetCollection<Inventario>("supermercado");


            var inventario = inventarios.FindAll().FirstOrDefault();

            var vendido = inventario.stockArticulos.FirstOrDefault(x => x.articulo.codigoBarra == agregarArticulo.codigoBarra);

            if (vendido.stock - agregarArticulo.unidades < 0)
                throw new Exception("Error el las unidades a ver son mayores al stock");

            vendido.stock = vendido.stock - agregarArticulo.unidades;

            inventarios.Update(inventario);
        
            return RedirectToAction("RealizarVenta");
        }
    }
}